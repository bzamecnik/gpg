import time, math, visual
from visual import vector

# Moving frame.
# A right-handed orthonormal system containing three orthogonal unit vectors:
#   r = reference (normal)
#   t = tangent
#   s = bitangent (s = t x r)
class Frame(object):
    def __init__(self, reference, tangent):
        self.r = visual.norm(reference)
        self.t = visual.norm(tangent)
        self.s = visual.norm(self.t.cross(self.r))
    
    def __str__(self):
        return "Frame[r: {}, s: {}, t: {}]".format(self.r, self.s, self.t)

    # Rotation angle difference around t axis.
    # Note: since the frame vectors are othogonal it is sufficient to compute
    # angle difference of their reference vectors only.
    # The angle difference of the respective s vectors should be the same.
    def diff_angle_t(self, otherFrame):
        return self.r.diff_angle(otherFrame.r)

    # Rotate the frame around the t axis by a specified angle.
    def rotate_t(self, angle):
        return Frame(self.r.rotate(angle, self.t), self.t)

def drawFrameAxes(position, frame):
    visual.arrow(pos=position, axis=frame.t, shaftwidth=0.05, color=visual.color.blue)
    visual.arrow(pos=position, axis=frame.s, shaftwidth=0.05)
    visual.arrow(pos=position, axis=frame.r, shaftwidth=0.05, color=visual.color.red)

def drawFrameProfiles(position, frame):
    visual.box(pos=position, axis=frame.t, up=frame.r, length=0.1, color=visual.color.yellow)

# Compute rotation minimizing frames for a set of points and associated
# tangent vector using the double reflection method.
#
# points - list of vectors
# tangents - list of vectors; must be of the same size as points
# initFrame - initial frame, Frame
def doubleReflection(points, tangents, initFrame):
    n = len(points)
    assert n == len(tangents)
    # computed frames with minimal rotation
    frames = [initFrame]
    for i in range(0, n - 1):
        # compute reflection vector of R_1
        v1 = points[i + 1] - points[i]
        c1 = v1.dot(v1)
        # compute r_i^L = R_1 * r_i
        ref_L_i = frames[i].r - (2 / c1) * v1.dot(frames[i].r) * v1
        # compute t_i^L = R_1 * t_i
        tan_L_i = frames[i].t - (2 / c1) * v1.dot(frames[i].t) * v1
        # compute reflection vector of R_2
        v2 = tangents[i+1] - tan_L_i
        c2 = v2.dot(v2)
        # compute r_(i+1) = R_2 * r_i^L
        ref_next = ref_L_i - (2 / c2) * v2.dot(ref_L_i) * v2
        frames.append(Frame(ref_next, tangents[i+1]))
    return frames

# Rotate the computed RMFs to meet some boundary conditions.
# The rotation function (t -> rotation angle) defined the
# amount of additional rotation.
def rotateFrames(frames, parameterValues, rotationFunc):
    assert(len(frames) == len(parameterValues))
    rotatedFrames = []
    for i in range(0, len(frames)):
        frame = frames[i].rotate_t(rotationFunc(parameterValues[i]))
        rotatedFrames.append(frame)
    return rotatedFrames

def squareAngularSpeedMinimizationFunc(maxAngle, twistsCount):
    return lambda t: t * (maxAngle + twistsCount * 2 * math.pi)

# Sample a curve in parametric space inside interval [0; 1].
# In addition compute tangents to sampled points of a curve along the curve
# parameter. Approximate the partial derivative by a simple difference.
# sampleCount: number of sample points
# return: tuple of list of points and tangents
def sampleCurve(curve, sampleCount):
    points = []
    tangents = []
    parameterValues = []
    step = 1.0 / (sampleCount - 1)
    t = 0
    last_point = curve(t)
    points.append(last_point)
    parameterValues.append(0)
    for i in range(1, sampleCount):
        t += step
        current_point = curve(t)
        points.append(current_point)
        tangents.append(visual.norm(current_point - last_point))
        parameterValues.append(t)
        last_point = current_point
    # use a point outside the [0; 1] interval to compute the tanget
    # note: the curve might not be always defined outside this interval!
    t += step
    tangents.append(visual.norm(curve(t) - last_point))
    return (points, tangents, parameterValues)

def testDoubleReflection():
    points = [vector(-1,0,0), vector(0,0,0), vector(1,0,0)]
    tangents = [vector(1,0.5,0.5), vector(1,0,0), vector(1,-0.5,-0.5)]
    initFrame = Frame(vector(0,0,1), tangents[0])
    rm_frames = doubleReflection(points, tangents, initFrame)
    assert(len(points) == len(rm_frames))
    for i in range(0, len(points)):
        print rm_frames[i]
        drawFrameAxes(points[i], rm_frames[i])

def helix(twistsCount, radius, pitch):
    s = lambda t: math.sin(twistsCount * 2 * math.pi * t)
    c = lambda t: math.cos(twistsCount * 2 * math.pi * t)
    return lambda t: vector(radius * s(t), pitch * (t - 0.5), radius * c(t))

def table_bottom(radius, legsCount, height):
    y = lambda t: height * math.sin(legsCount * 2 * math.pi * t)
    s = lambda t: math.sin(2 * math.pi * t)
    c = lambda t: math.cos(2 * math.pi * t)
    return lambda t: vector(radius * s(t), y(t), radius * c(t))

def circle(radius):
    return lambda t: vector(
        radius * math.sin(2 * math.pi * t),
        0,
        radius * math.cos(2 * math.pi * t),
        )

def testSampleCurve(curve, sampleCount):
    # sample the curve
    (points, tangents, parameterValues) = sampleCurve(curve, sampleCount)
    # compute the rotation minimization frames
    firstFrame = Frame(vector(0,0,-1), tangents[0])
    lastFrame = Frame(vector(0,0,1), tangents[-1])
    rm_frames = doubleReflection(points, tangents, firstFrame)
    assert(len(points) == len(rm_frames))

    maxAngle = -(rm_frames[-1].diff_angle_t(lastFrame))
    print("last RMF: " + str(rm_frames[-1]))
    print("last frame BC: " + str(lastFrame))
    print("angle diff: " + str(maxAngle))
    adjusted_frames = rotateFrames(rm_frames, parameterValues,
        squareAngularSpeedMinimizationFunc(maxAngle, 1))
    #frames = rm_frames
    frames = adjusted_frames
    
    # display the results
    #print points
    #print tangents
    visual.points(pos=points, size=5, color=visual.color.red)
    for i in range(0, len(points)):
        #print frames[i]
        drawFrameAxes(points[i], adjusted_frames[i])
        drawFrameProfiles(points[i], adjusted_frames[i])

drawFrameAxes((0,0,0), Frame(vector(0,1,0), vector(1,0,0)))
#testSampleCurve(helix(2, 4, 8), 100)
#testSampleCurve(table_bottom(5, 5, 1), 100)
testSampleCurve(circle(5), 100)
