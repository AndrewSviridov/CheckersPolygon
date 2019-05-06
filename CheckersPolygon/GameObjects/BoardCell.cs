﻿using CheckersPolygon.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CheckersPolygon.Helpers;

namespace CheckersPolygon.GameObjects
{
    /* Cell
     */
    public class BoardCell : IDrawable
    {
        public bool IsActive { get; set; } // If active - black, no - white
        public byte ZOrder { get; set; } // The rendering layer
        public CheckersCoordinateSet Position { get; set; } // Combined coordinates
        public Color color; // Color of the cell
        public bool Highlighted { get; set; } // Is the cell

        /* Determined by:
         * - Flag of activity
         * - The combined position
         */
        public BoardCell(bool isActive, CheckersCoordinateSet position)
        {
            this.IsActive = isActive;
            if (IsActive) color = Constants.activeCellColor;
            else color = Constants.passiveCellColor;
            this.Highlighted = false;
            this.Position = position;
            this.ZOrder = 0;
        }

        /* Cell rendering
         */
        public void Draw(Graphics graph)
        {
            graph.FillRectangle(new SolidBrush(color),
                Position.ScreenPosition.X,
                Position.ScreenPosition.Y,
                Position.DrawableSize.Width,
                Position.DrawableSize.Height);

            if (Highlighted) // If highlighted
                graph.DrawRectangle(new Pen(Constants.highlightCellColor, 4),
                    Position.ScreenPosition.X,
                    Position.ScreenPosition.Y,
                    Position.DrawableSize.Width,
                    Position.DrawableSize.Height);
        }
    }
}
