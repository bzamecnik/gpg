import time, math, visual
from visual import vector

# Computing rotation minimization frames using the double reflection method
#
# Author: Bohumir Zamecnik <bohumir [dot] zamecnik [at] gmail [dot] com>
# Date: 2011/02/24
#
# References:
# [1] W. Wang, B. Juttler, D. Zheng, Y. Liu: Computation of Rotation Minimizing
#     Frame in Computer Graphics, 2007
# 

# ----- Frame computation -----

# Moving frame.
# A right-handed orthonormal system containing three orthogonal unit vectors:
#   r = reference (normal)
#   t = tangent
#   s = bitangent (s = t x r)
#
# The reference vector is projected so that it is made orthogonal to the
# tangent vector. The bitangent vector is made orthogonal to the others.
# All vectors are then normalized. This is one step of the Gram-Schmidt
# orthogonalization.
class Frame(object):
    def __init__(self, reference, tangent):
        self.t = visual.norm(tangent)
        # make reference vector orthogonal to tangent
        proj_r_to_t = reference.dot(tangent) / tangent.dot(tangent) * tangent
        self.r = visual.norm(reference - proj_r_to_t)
        # make bitangent vector orthogonal to the others
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

def squareAngularSpeedMinimizationFunc(maxAngle, twistCount):
    return lambda t: t * (maxAngle + twistCount * 2 * math.pi)

def adjustFramesWithBoundaryCondition(frames, firstFrame, lastFrame,
        parameterValues, adjustmentFunc):
    maxAngle = -(frames[-1].diff_angle_t(lastFrame))
    #print("last RMF: " + str(rm_frames[-1]))
    #print("last frame BC: " + str(lastFrame))
    #print("angle diff: " + str(maxAngle))
    adjusted_frames = rotateFrames(frames, parameterValues,
        adjustmentFunc(maxAngle))
    return adjusted_frames

# Sample a curve and compute rotation minimization frames in each sampled point.
#
# curve: curve to be sampled; lambda function parametrized by one parameter
# sampleCount: number of sample points of the curve
# boundaryConditions: boundary conditions on the frames
#   Currently only first and last frame can be specified. The first 

def computeRMF(curve, sampleCount, boundaryConditions, adjustFrames=True,
        adjustmentFunc=None):
    # sample the curve
    (points, tangents, parameterValues) = sampleCurve(curve, sampleCount)
    # compute the rotation minimization frames
    firstFrame = Frame(boundaryConditions[0], tangents[0])
    rm_frames = doubleReflection(points, tangents, firstFrame)
    assert(len(points) == len(rm_frames))
    frames = rm_frames
    if adjustFrames:
        assert(adjustFrames and (len(boundaryConditions) > 1))
        lastFrame = Frame(boundaryConditions[1], tangents[-1])
        # adjust (rotate) frames to meet the boundary conditions
        frames = adjustFramesWithBoundaryCondition(rm_frames, firstFrame, lastFrame, parameterValues, adjustmentFunc)
    return (points, frames)

# ----- Curve sampling -----

# Sample a curve in parametric space inside interval [0; 1].
# In addition compute tangents to sampled points of a curve along the curve
# parameter. Approximate the partial derivative by a simple difference.
#
# curve: curve to be sampled; lambda function parametrized by one parameter
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

# ---- Visualization routines -----

# Create a surface from a sequence of extruded profile vertices.
# Several square faces connect consecutive profiles.
# Optionally end caps can be created.
# The profile is assumed to be square (for the caps).
#
# Parameters:
#
# vertices: [((x,y,z), (x,y,z), ..., ...), (...)]
#   the list contains profile tuples, each containing a tuple of vertices
#
#
# fillEnds: (true/false) indicates whether to create end caps
def makeFaces(vertices, fillEnds=False):
    f = visual.faces(color=(1,1,1))
    # one end
    if (fillEnds):
        f.append(pos = vertices[0][0])
        f.append(pos = vertices[0][1])
        f.append(pos = vertices[0][2])
        f.append(pos = vertices[0][0])
        f.append(pos = vertices[0][2])
        f.append(pos = vertices[0][3])
    for i in range(0, len(vertices) - 1):
        profile = vertices[i]
        profile_len = len(profile)
        next_profile = vertices[i+1]
        for j in range(0, profile_len):
            # two triangles to make a square
            f.append(pos = profile[j % profile_len])
            f.append(pos = next_profile[j % profile_len])
            f.append(pos = next_profile[(j+1) % profile_len])
            f.append(pos = profile[j % profile_len])
            f.append(pos = next_profile[(j+1) % profile_len])
            f.append(pos = profile[(j+1) % profile_len])
    # another end
    if (fillEnds):
        f.append(pos = vertices[-1][0])
        f.append(pos = vertices[-1][2])
        f.append(pos = vertices[-1][1])
        f.append(pos = vertices[-1][0])
        f.append(pos = vertices[-1][3])
        f.append(pos = vertices[-1][2])
    f.make_normals()
    return f

# Make a sweep surface by sweeping a square profile along a curve
# with sampled points and given frames.
def makeSweepSurface(points, frames, width=1.0):
    profiles = []
    for i in range(0, len(points)):
        point = points[i]
        frame = frames[i]
        r = 0.5 * width * frame.r
        s = 0.5 * width * frame.s
        profile = (
            point - r - s,
            point - r + s,
            point + r + s,
            point + r - s
            )
        profiles.append(profile)
    return makeFaces(profiles, True)

# Draw axes of a frames as color-coded arrows.
def drawFrameAxes(position, frame):
    visual.arrow(pos=position, axis=frame.t, shaftwidth=0.05,
        color=visual.color.blue)
    visual.arrow(pos=position, axis=frame.s, shaftwidth=0.05)
    visual.arrow(pos=position, axis=frame.r, shaftwidth=0.05,
        color=visual.color.red)

# Draw normal planes of a list of frames as squares.
def drawFrameProfiles(position, frame):
    visual.box(pos=position, axis=frame.t, up=frame.r, length=0.1,
        color=visual.color.yellow, opacity=0.5)

# Draw a list of frames located at specified positions.
def drawFrames(points, frames):
    visual.points(pos=points, size=5, color=visual.color.red)
    for i in range(0, len(points)):
        drawFrameAxes(points[i], frames[i])
        drawFrameProfiles(points[i], frames[i])

def clearScene():
    scene = visual.display.get_selected()
    for obj in scene.objects:
        obj.visible = False
        del obj

# ----- Demo -----

class Demo(object):
    def  __init__(self):
        visual.scene = visual.display(width=800, height=800)
        
        self.exampleCurves = [
            self.helix(2, 4, 8),
            self.table_bottom(5, 5, 1),
            self.circle(5),
            self.legs(),
            ]
        self.curve = self.exampleCurves[0]
        self.sampleCount = 50
        self.boundaryConditions = (vector(0,1,-1), vector(0,0,1))
        #self.boundaryConditions = (vector(0,0,-1), vector(0,0,1))
        self.twistCount = 0
        self.adjustmentFunc = lambda maxAngle: squareAngularSpeedMinimizationFunc(
            maxAngle, twistCount=self.twistCount)
        self.adjustFrames = True
        self.showSweepSurface = True
        self.showFrames = True
        self.showWorldFrame = True
        self.fullscreen = False
        
        self.sampleCountIncreaseFactor = 0.75

    # ---- Example curves -----

    def helix(self, twistsCount, radius, pitch):
        s = lambda t: math.sin(twistsCount * 2 * math.pi * t)
        c = lambda t: math.cos(twistsCount * 2 * math.pi * t)
        return lambda t: vector(radius * s(t), pitch * (t - 0.5), radius * c(t))

    def table_bottom(self, radius, legsCount, height):
        y = lambda t: height * math.sin(legsCount * 2 * math.pi * t)
        s = lambda t: math.sin(2 * math.pi * t)
        c = lambda t: math.cos(2 * math.pi * t)
        return lambda t: vector(radius * s(t), y(t), radius * c(t))

    def circle(self, radius):
        return lambda t: vector(
            radius * math.sin(2 * math.pi * t),
            0,
            radius * math.cos(2 * math.pi * t),
            )

    def legs(self):
        u = lambda t: 5*t - 2.5
        return lambda t: vector(u(t) * math.cos(0.5*t), 3 - (u(t) * u(t)), math.sin(8 * t))
    
    def drawScene(self):
        # draw the frame of world coordinates
        if self.showWorldFrame:
            drawFrameAxes((0,0,0), Frame(vector(0,1,0), vector(1,0,0)))

        (points, frames) = computeRMF(self.curve, self.sampleCount,
            self.boundaryConditions,
            self.adjustFrames, self.adjustmentFunc)
        # display the results
        if self.showFrames:
            drawFrames(points, frames)
        if self.showSweepSurface:
            makeSweepSurface(points, frames, 0.9)
    
    def refresh(self):
        clearScene()
        self.drawScene()

    def toggleFullscreen(self):
        self.fullscreen = not self.fullscreen
        if self.fullscreen:
            self.windowSize = (visual.scene.width, visual.scene.height)
            self.windowPos = (visual.scene.x, visual.scene.y)
        visual.scene.visible = False
        visual.scene.fullscreen = self.fullscreen
        if not self.fullscreen:
            (visual.scene.width, visual.scene.height) = self.windowSize
            (visual.scene.x, visual.scene.y) = self.windowPos
        visual.scene.visible = True

    def printInfo(self):
        print "Curve sample count: " + str(self.sampleCount)
        print "Adjust frames: " + str(self.adjustFrames)
        print "Show sweep surface: " + str(self.showSweepSurface)
        print "Show frames: " + str(self.showFrames)
        print "Show world frame: " + str(self.showWorldFrame)
        print "Boundary conditions: " + str(self.boundaryConditions)
        print "Twist count:" + str( self.twistCount)
        print

    def printHelp(self):
        print "Rotation minimization frame demo."
        print
        print "Mouse commands:"
        print " right button + move: change the angle of view on an orbit"
        print " both buttons + move up/down: change the radius on an orbit"
        print
        print "Keyboard commands:"
        print " <space> - recompute the scene"
        print " a - toggle adjusting frames (additional rotation using boundary conditions)"
        print " c - increase the number curve samples by factor " + str(self.sampleCountIncreaseFactor)
        print " C - decrease the number curve samples by factor " + str(1.0 / self.sampleCountIncreaseFactor)
        print " f - toggle showing frames"
        print " h - show this help"
        print " n - disable interactive mode and switch to console"
        print "     enable interactive mode by: demo.interactiveLoop()"
        print " p - print info"
        print " r - use another curve from the list of example curves"
        print " s - toggle showing sweep surface"
        print " t - increase twist by 2 * PI"
        print " T - decrease twist by 2 * PI"
        print " w - toggle showing the world frame"
        print " F11 - toggle fullscreen and windowed mode"
        print
        print "Example curves: helix, table legs, circle"

    def interactiveLoop(self):
        while True:
            visual.rate(50)
            if visual.scene.kb.keys: # event waiting to be processed?
                key = visual.scene.kb.getkey() # get keyboard info
                if len(key) == 1:
                    if key == ' ':
                        demo.refresh()
                    elif key == 'a':
                        demo.adjustFrames = not demo.adjustFrames
                        demo.refresh()
                    elif key == 'c':
                        demo.sampleCount = max(3, int(demo.sampleCount * self.sampleCountIncreaseFactor))
                        print 'Curve sample count: ' + str(demo.sampleCount)
                        demo.refresh()
                    elif key == 'C':
                        demo.sampleCount = int(demo.sampleCount * (1 / self.sampleCountIncreaseFactor))
                        print 'Curve sample count: ' + str(demo.sampleCount)
                        demo.refresh()
                    elif key == 'f':
                        demo.showFrames = not demo.showFrames
                        demo.refresh()
                    elif key == 'n':
                        break
                    elif key == 'p':
                        demo.printInfo()
                    elif key == 'h' or key == '?':
                        demo.printHelp()
                    elif key == 'r':
                        # select next curve from the list of example curves
                        # wrapping around the list
                        selectedCurveIndex = 0
                        try:
                            selectedCurveIndex = demo.exampleCurves.index(demo.curve)
                        except ValueError:
                            print "Warning: Cannot find current curve, using the first one instead."
                        selectedCurveIndex += 1
                        selectedCurveIndex %= len(demo.exampleCurves)
                        demo.curve = demo.exampleCurves[selectedCurveIndex]
                        demo.refresh()
                    elif key == 's':
                        demo.showSweepSurface = not demo.showSweepSurface
                        demo.refresh()
                    elif key == 't':
                        demo.twistCount += 1
                        print 'Twist count: ' + str(demo.twistCount)
                        demo.refresh()
                    elif key == 'T':
                        demo.twistCount -= 1
                        print 'Twist count: ' + str(demo.twistCount)
                        demo.refresh()
                    elif key == 'w':
                        demo.showWorldFrame = not demo.showWorldFrame
                        demo.refresh()
                else:
                    if key == 'f11':
                        self.toggleFullscreen()
    
    def run(self):
        print "Rotation minimization frame demo."
        print "Press 'h' key for help on controls."
        self.drawScene()
        self.interactiveLoop()
        

demo = Demo()
demo.run()
