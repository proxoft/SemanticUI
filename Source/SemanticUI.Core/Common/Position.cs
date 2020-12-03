using System;

using static Proxoft.SemanticUI.Core.Position;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum Position
    {
        Default = 0,
        Top     = 1 << 0,
        Middle  = 1 << 1,
        Bottom  = 1 << 2,
        Left    = 1 << 3,
        Center  = 1 << 4,
        Right   = 1 << 5,

        TopLeft = Top | Left,
        TopCenter = Top | Center,
        TopRight = Top | Right,
        LeftCenter = Left | Center,
        RightCenter = Right | Center,
        BottomLeft = Bottom | Left,
        BottomCenter = Bottom | Center,
        BottomRight = Bottom | Right,
    }

    public static class PositionExtensions
    {
        public static string ToAlignmentClass(this Position position)
        {
            switch (position)
            {
                case Left:
                case Right:
                case Center:
                    return position.ToString().ToLower() + " aligned";
                default:
                    return string.Empty;
            }
        }

        public static string ToVerticalAlignmentClass(this Position position)
        {
            switch (position)
            {
                case Top:
                case Bottom:
                case Middle:
                    return position.ToString().ToLower() + " aligned";
                default:
                    return string.Empty;
            }
        }

        public static string ToFloatedClass(this Position position)
        {
            switch (position)
            {
                case Right:
                case Left:
                    return position.ToString().ToLower() + " floated";
                default:
                    return string.Empty;
            }
        }

        public static string ToSpacedClass(this Position position)
        {
            if(position.HasFlag(Left) && position.HasFlag(Right))
            {
                return "spaced";
            }

            if (position.HasFlag(Left) || position.HasFlag(Right))
            {
                return position.ToString().ToLower() + " spaced";
            }

            return string.Empty;
        }

        public static string ToPositionClass(this Position position)
        {
            if (position.HasFlag(Top))
            {
                return $"top {position.HorizontalPosition(ignoreCenter: false)}";
            }

            if (position.HasFlag(Center))
            {
                return $"{position.HorizontalPosition(ignoreCenter: true)} center";
            }

            if (position.HasFlag(Bottom))
            {
                return $"bottom {position.HorizontalPosition(ignoreCenter: false)}";
            }

            return string.Empty;
        }

        public static string ToAttachedClass(this Position position)
        {
            if (position.HasFlag(Middle))
            {
                return "attached";
            }

            var @class = string.Empty;
            if (position.HasFlag(Top))
            {
                @class += "top" + position.AttachedHorizontal();
            }
            else if (position.HasFlag(Bottom))
            {
                @class += "bottom" + position.AttachedHorizontal();
            }

            return string.IsNullOrEmpty(@class)
                ? @class
                : @class + " attached";
        }

        public static string ToLabelClass(this Position position)
        {
            return position.HasFlag(Right)
                ? "right"
                : string.Empty;
        }

        private static string HorizontalPosition(this Position position, bool ignoreCenter = false)
        {
            if (position.HasFlag(Left))
            {
                return "left";
            }

            if (position.HasFlag(Right))
            {
                return "right";
            }

            if (!ignoreCenter && position.HasFlag(Center))
            {
                return "center";
            }

            return "right";
        }

        private static string AttachedHorizontal(this Position position)
        {
            if (position.HasFlag(Left))
            {
                return " left";
            }

            if (position.HasFlag(Right))
            {
                return " right";
            }

            return string.Empty;
        }
    }
}
