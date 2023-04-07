# About
This is my implementation the GeometryLibrary for Assignment 3. It provides the 3 required classes:

- Tetrahedron
- Cuboid
- Cylinder

## Implementation

To help with the implementation I introduced 2 interfaces `ISurface` and `IVolume`, the abstract class `Polyhedron` and created my own `Vector3` struct.

# Class Documentation
## Tetrahedron

Stores 4 vertices in `_points` Array.

- `==` operator compares 2 tetrahedra , returns `true` if for each point in left operand there exists a point with the same values in the right operand.
- `Centroid()` returns the Centroid of the tetrahedron as `Vector3`
- `SurfaceArea()` returns the surface area of the tetrahedron as `float`
- `Volume()` returns the volume of the tetrahedron as `float`

## Cuboid
Stores 8 vertices in `_points`Array

- `==` operator compares 2 cuboids, returns `true` if for each point in left operand there exists a point with the same values in the right operand.
- `Centroid()` returns the Centroid of the cuboid as `Vector3`
- `SurfaceArea()` returns the surface area of the cuboid as `float`
- `Volume()` returns the volume of the cuboid as `float`

## Cylinder
Stores 2 vertices to store the 2 bases of a cylinder (`Vector3`) as well as the radius as `float`.

- `==` operator compares 2 cylinder, returns `true` if for each point in left operand there exists a point with the same values in the right operand. Additionally checks if the cylinders share the same radius.
- `Height()` returns height of the cylinder, I use the distance between the 2 bases
- `BottomArea()` returns the area of the bases of the cylinder as `float`
- `SurfaceArea()` returns the surface are of the cylinder as `float`
- `Volume()` returns the volume of the cylinder as `float`

# LICENSE

Copyright 2023 Georg Becker

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.