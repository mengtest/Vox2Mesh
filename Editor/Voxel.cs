using Unity.Mathematics;
using UnityEngine;
using System;

namespace Vox2Mesh
{
    public struct Voxel : IFormattable
    {
        public bool solid;
        public Color32 color;

        public Voxel(Color32 color, bool solid = true)
        {
            this.solid = solid;
            this.color = color;
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return $"Voxel(color: {color}, solid: {solid})";
        }

        public static readonly int3[] directions =
        {
            new int3(0, 0, -1),
            new int3(1, 0, 0),
            new int3(0, 0, 1),
            new int3(-1, 0, 0),
            new int3(0, 1, 0),
            new int3(0, -1, 0),
        };

        public static readonly int[] triangles = { 0, 1, 2, 0, 2, 3 };
        public static readonly int[] trianglesFlipped = { 1, 2, 3, 1, 3, 0 };

        public static readonly int3[][] vertices = {
            new int3[] {
                new int3(0, 0, 0),
                new int3(0, 1, 0),
                new int3(1, 1, 0),
                new int3(1, 0, 0),
            },
            new int3[] {
                new int3(1, 0, 0),
                new int3(1, 1, 0),
                new int3(1, 1, 1),
                new int3(1, 0, 1),
            },
            new int3[] {
                new int3(1, 0, 1),
                new int3(1, 1, 1),
                new int3(0, 1, 1),
                new int3(0, 0, 1),
            },
            new int3[] {
                new int3(0, 0, 1),
                new int3(0, 1, 1),
                new int3(0, 1, 0),
                new int3(0, 0, 0),
            },
            new int3[] {
                new int3(0, 1, 0),
                new int3(0, 1, 1),
                new int3(1, 1, 1),
                new int3(1, 1, 0),
            },
            new int3[] {
                new int3(0, 0, 1),
                new int3(0, 0, 0),
                new int3(1, 0, 0),
                new int3(1, 0, 1),
            }
        };

        // [face][vertex][offset]
        public static readonly int3[][][] ambientOcclusion = {
            new int3[][] {
                new int3[3] {
                    new int3(0, -1, -1),
                    new int3(-1, 0, -1),
                    new int3(-1, -1, -1),
                },
                new int3[3] {
                    new int3(0, 1, -1),
                    new int3(-1, 0, -1),
                    new int3(-1, 1, -1),
                },
                new int3[3] {
                    new int3(0, 1, -1),
                    new int3(1, 0, -1),
                    new int3(1, 1, -1),
                },
                new int3[3] {
                    new int3(0, -1, -1),
                    new int3(1, 0, -1),
                    new int3(1, -1, -1),
                },
            },
            new int3[][] {
                new int3[3] {
                    new int3(1, -1, 0),
                    new int3(1, 0, -1),
                    new int3(1, -1, -1),
                },
                new int3[3] {
                    new int3(1, 1, 0),
                    new int3(1, 0, -1),
                    new int3(1, 1, -1),
                },
                new int3[3] {
                    new int3(1, 1, 0),
                    new int3(1, 0, 1),
                    new int3(1, 1, 1),
                },
                new int3[3] {
                    new int3(1, -1, 0),
                    new int3(1, 0, 1),
                    new int3(1, -1, 1),
                },
            },
            new int3[][] {
                new int3[3] {
                    new int3(0, -1, 1),
                    new int3(1, 0, 1),
                    new int3(1, -1, 1),
                },
                new int3[3] {
                    new int3(0, 1, 1),
                    new int3(1, 0, 1),
                    new int3(1, 1, 1),
                },
                new int3[3] {
                    new int3(0, 1, 1),
                    new int3(-1, 0, 1),
                    new int3(-1, 1, 1),
                },
                new int3[3] {
                    new int3(0, -1, 1),
                    new int3(-1, 0, 1),
                    new int3(-1, -1, 1),
                },
            },
            new int3[][] {
                new int3[3] {
                    new int3(-1, -1, 0),
                    new int3(-1, 0, 1),
                    new int3(-1, -1, 1),
                },
                new int3[3] {
                    new int3(-1, 1, 0),
                    new int3(-1, 0, 1),
                    new int3(-1, 1, 1),
                },
                new int3[3] {
                    new int3(-1, 1, 0),
                    new int3(-1, 0, -1),
                    new int3(-1, 1, -1),
                },
                new int3[3] {
                    new int3(-1, -1, 0),
                    new int3(-1, 0, -1),
                    new int3(-1, -1, -1),
                },
            },
            new int3[][] {
                new int3[3] {
                    new int3(-1, 1, 0),
                    new int3(0, 1, -1),
                    new int3(-1, 1, -1),
                },
                new int3[3] {
                    new int3(-1, 1, 0),
                    new int3(0, 1, 1),
                    new int3(-1, 1, 1),
                },
                new int3[3] {
                    new int3(1, 1, 0),
                    new int3(0, 1, 1),
                    new int3(1, 1, 1),
                },
                new int3[3] {
                    new int3(1, 1, 0),
                    new int3(0, 1, -1),
                    new int3(1, 1, -1),
                },
            },
            new int3[][] {
                new int3[3] {
                    new int3(-1, -1, 0),
                    new int3(0, -1, 1),
                    new int3(-1, -1, 1),
                },
                new int3[3] {
                    new int3(-1, -1, 0),
                    new int3(0, -1, -1),
                    new int3(-1, -1, -1),
                },
                new int3[3] {
                    new int3(1, -1, 0),
                    new int3(0, -1, -1),
                    new int3(1, -1, -1),
                },
                new int3[3] {
                    new int3(1, -1, 0),
                    new int3(0, -1, 1),
                    new int3(1, -1, 1),
                },
            },
        };
    }
}