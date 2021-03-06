﻿using Gwen.Control;
using Newtonsoft.Json;

namespace Gwen.ControlInternal
{
    /// <summary>
    /// Inner panel of tab control.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(Serialization.GwenConverter))]
    public class TabControlInner : ControlBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabControlInner"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        internal TabControlInner(ControlBase parent) : base(parent)
        {
        }

        /// <summary>
        /// Renders the control using specified skin.
        /// </summary>
        /// <param name="skin">Skin to use.</param>
        protected override void render(Skin.SkinBase skin)
        {
            skin.DrawTabControl(this);
        }
    }
}
