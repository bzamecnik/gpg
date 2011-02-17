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

def drawFrameAxes(position, frame):
    visual.arrow(pos=position, axis=frame.t, shaftwidth=0.05, color=visual.color.blue)
    visual.arrow(pos=position, axis=frame.s, shaftwidth=0.05)
    visual.arrow(pos=position, axis=frame.r, shaftwidth=0.05, color=visual.color.red)

#drawFrameAxes([0, 0, 0], Frame(vector(0,1,0), vector(1,0,0)))

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

#initFrame = Frame(vector(0,1,0), vector(1,0,0))
#print initFrame

# Sample a curve in parametric space inside interval [0; 1].
# In addition compute tangents to sampled points of a curve along the curve
# parameter. Approximate the partial derivative by a simple difference.
# samples: number of sample points
# return: tuple of list of points and tangents
def sampleCurve(curve, samples):
    points = []
    tangents = []
    step = 1.0 / (samples - 1)
    t = 0
    last_point = curve(t)
    points.append(last_point)
    for i in range(1, samples):
        t += step
        current_point = curve(t)
        points.append(current_point)
        tangents.append(visual.norm(current_point - last_point))
        last_point = current_point
    # use a point outside the [0; 1] interval to compute the tanget
    # note: the curve might not be always defined outside this interval!
    t += step
    tangents.append(visual.norm(curve(t) - last_point))
    return (points, tangents)

def testDoubleReflection():
    points = [vector(-1,0,0), vector(0,0,0), vector(1,0,0)]
    tangents = [vector(1,0.5,0.5), vector(1,0,0), vector(1,-0.5,-0.5)]
    initFrame = Frame(vector(0,0,1), tangents[0])
    rm_frames = doubleReflection(points, tangents, initFrame)
    assert(len(points) == len(rm_frames))
    for i in range(0, len(points)):
        print rm_frames[i]
        drawFrameAxes(points[i], rm_frames[i])

def helix(twistsCount, radius):
    s = lambda t: math.sin(twistsCount * 2 * math.pi * t)
    c = lambda t: math.cos(twistsCount * 2 * math.pi * t)
    return lambda t: vector(radius * t, radius * s(t), radius * c(t))

def testSampleCurve(samples):
    # sample the curve
    (points, tangents) = sampleCurve(helix(2, 4), samples)
    # compute the rotation minimization frames
    initFrame = Frame(vector(0,0,-1), tangents[0])
    rm_frames = doubleReflection(points, tangents, initFrame)
    assert(len(points) == len(rm_frames))
    # display the results
    #print points
    #print tangents
    visual.points(pos=points, size=10, color=visual.color.red)
    for i in range(0, len(points)):
        #print rm_frames[i]
        drawFrameAxes(points[i], rm_frames[i])

drawFrameAxes((0,0,0), Frame(vector(0,1,0), vector(1,0,0)))
testSampleCurve(100)

