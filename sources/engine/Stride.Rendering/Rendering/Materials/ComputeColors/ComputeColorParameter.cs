// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
#pragma warning disable SA1402 // File may only contain a single class
using System.ComponentModel;

using Stride.Core;
using Stride.Core.Annotations;
using Stride.Core.Mathematics;
using Stride.Graphics;

namespace Stride.Rendering.Materials.ComputeColors
{
    /// <summary>
    /// Base class for a Color compute color parameter.
    /// </summary>
    [DataContract("ComputeColorParameter")]
    public abstract class ComputeColorParameter : IComputeColorParameter
    {
    }

    [DataContract("ComputeColorParameterTexture")]
    public class ComputeColorParameterTexture : ComputeColorParameter
    {
        public ComputeTextureColor Texture { get; } = new ComputeTextureColor();
    }

    [DataContract]
    public abstract class ComputeColorParameterValue<T> : IComputeColorParameter
    {
        [DataMember(10)]
        [InlineProperty]
        public T Value { get; set; }
    }

    [DataContract("ComputeColorStringParameter")]
    public class ComputeColorStringParameter : ComputeColorParameterValue<string>
    {
        public ComputeColorStringParameter()
            : base()
        {
            Value = string.Empty;
        }
    }

    [DataContract("ComputeColorParameterBool")]
    public class ComputeColorParameterBool : ComputeColorParameterValue<bool>
    {
        public ComputeColorParameterBool()
            : base()
        {
            Value = false;
        }
    }

    [DataContract("ComputeColorParameterFloat")]
    public class ComputeColorParameterFloat : ComputeColorParameterValue<float>
    {
        public ComputeColorParameterFloat()
            : base()
        {
            Value = 0.0f;
        }
    }

    [DataContract("ComputeColorParameterInt")]
    public class ComputeColorParameterInt : ComputeColorParameterValue<int>
    {
        public ComputeColorParameterInt()
            : base()
        {
            Value = 0;
        }
    }

    [DataContract("ComputeColorParameterFloat2")]
    public class ComputeColorParameterFloat2 : ComputeColorParameterValue<Vector2>
    {
        public ComputeColorParameterFloat2()
            : base()
        {
            Value = Vector2.Zero;
        }
    }

    [DataContract("ComputeColorParameterFloat3")]
    public class ComputeColorParameterFloat3 : ComputeColorParameterValue<Vector3>
    {
        public ComputeColorParameterFloat3()
            : base()
        {
            Value = Vector3.Zero;
        }
    }

    [DataContract("ComputeColorParameterFloat4")]
    public class ComputeColorParameterFloat4 : ComputeColorParameterValue<Vector4>
    {
        public ComputeColorParameterFloat4()
            : base()
        {
            Value = Vector4.Zero;
        }
    }

    [DataContract("ComputeColorParameterSampler")]
    public class ComputeColorParameterSampler : IComputeColorParameter
    {
        /// <summary>
        /// The texture filtering mode.
        /// </summary>
        [DataMember(10)]
        [DefaultValue(TextureFilter.Linear)]
        public TextureFilter Filtering { get; set; }

        /// <summary>
        /// The texture address mode.
        /// </summary>
        [DataMember(20)]
        [DefaultValue(TextureAddressMode.Wrap)]
        public TextureAddressMode AddressModeU { get; set; }

        /// <summary>
        /// The texture address mode.
        /// </summary>
        [DataMember(30)]
        [DefaultValue(TextureAddressMode.Wrap)]
        public TextureAddressMode AddressModeV { get; set; }

        public ComputeColorParameterSampler()
        {
            Filtering = TextureFilter.Linear;
            AddressModeU = TextureAddressMode.Wrap;
            AddressModeV = TextureAddressMode.Wrap;
        }
    }
}
