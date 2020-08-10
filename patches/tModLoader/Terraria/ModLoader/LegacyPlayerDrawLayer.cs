﻿using System.Collections.Generic;
using Terraria.DataStructures;

namespace Terraria.ModLoader
{
	/// <summary> This class represents a DrawLayer for the player, and uses PlayerDrawInfo as its InfoType. Drawing should be done by adding Terraria.DataStructures.DrawData objects to Main.playerDrawData. </summary>
	[Autoload(false)]
	public sealed class LegacyPlayerDrawLayer : PlayerDrawLayer
	{
		/// <summary> The delegate of this method, which can either do the actual drawing or add draw data, depending on what kind of layer this is. </summary>
		public readonly LayerFunction Layer;

		private readonly string CustomName;
		private readonly bool HeadLayer;

		public override string Name => CustomName;
		public override bool IsHeadLayer => HeadLayer;
		public override DrawLayer<PlayerDrawSet> Parent { get; }

		/// <summary> Creates a LegacyPlayerLayer with the given mod name, identifier name, and drawing action. </summary>
		public LegacyPlayerDrawLayer(Mod mod, string name, bool isHeadLayer, LayerFunction layer) {
			Mod = mod;
			CustomName = name;
			Layer = layer;
			HeadLayer = isHeadLayer;
		}

		/// <summary> Creates a LegacyPlayerLayer with the given mod name, identifier name, parent layer, and drawing action. </summary>
		public LegacyPlayerDrawLayer(Mod mod, string name, bool isHeadLayer, PlayerDrawLayer parent, LayerFunction layer) : this(mod, name, isHeadLayer, layer) {
			Parent = parent;
		}

		public override void GetDefaults(Player drawPlayer, out bool visible, out float depth) {
			depth = 0f;
			visible = true;
		}

		public override void Draw(ref PlayerDrawSet drawInfo) => Layer(ref drawInfo);
	}
}
