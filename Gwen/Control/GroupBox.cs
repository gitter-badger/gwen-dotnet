﻿using Newtonsoft.Json;

namespace Gwen.Control
{
    /// <summary>
    /// Group box (container).
    /// </summary>
    /// <remarks>Don't use autosize with docking.</remarks>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(Serialization.GwenConverter))]
    public class GroupBox : Label
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupBox"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        public GroupBox(ControlBase parent) : base(parent)
        {
			AutoSizeToContents = false;

            // Set to true, because it's likely that our
            // children will want mouse input, and they
            // can't get it without us..
            MouseInputEnabled = true;
            KeyboardInputEnabled = true;

            TextPadding = new Padding(10, 0, 10, 0);
            Alignment = Pos.Top | Pos.Left;
            Invalidate();

            innerPanel = new ControlBase(this);
            innerPanel.Dock = Pos.Fill;
            innerPanel.Margin = new Margin(5, TextHeight+5, 5, 5);
            //Margin = new Margin(5, 5, 5, 5);
        }

        /// <summary>
        /// Lays out the control's interior according to alignment, padding, dock etc.
        /// </summary>
        /// <param name="skin">Skin to use.</param>
        protected override void layout(Skin.SkinBase skin)
        {
            base.layout(skin);
            if (AutoSizeToContents)
            {
                DoSizeToContents();
            }
        }

        /// <summary>
        /// Renders the control using specified skin.
        /// </summary>
        /// <param name="skin">Skin to use.</param>
        protected override void render(Skin.SkinBase skin)
        {
            skin.DrawGroupBox(this, TextX, TextHeight, TextWidth);
        }

        /// <summary>
        /// Sizes to contents.
        /// </summary>
        public override void SizeToContents()
        {
            // we inherit from Label and shouldn't use its method.
            DoSizeToContents();
        }

        protected virtual void DoSizeToContents()
        {
            innerPanel.SizeToChildren();
            SizeToChildren();
            if (Width < TextWidth + TextPadding.Right + TextPadding.Left)
                Width = TextWidth + TextPadding.Right + TextPadding.Left;
        }
    }
}
