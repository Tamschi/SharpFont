﻿#region MIT License
/*Copyright (c) 2012 Robert Rouhani <robert.rouhani@gmail.com>

SharpFont based on Tao.FreeType, Copyright (c) 2003-2007 Tao Framework Team

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/
#endregion

using System;
using System.Runtime.InteropServices;

using SharpFont.TrueType.Internal;

namespace SharpFont.TrueType
{
	/// <summary>
	/// A structure used to model a TrueType vertical header, the ‘vhea’ table,
	/// as well as the corresponding vertical metrics table, i.e., the ‘vmtx’
	/// table.
	/// </summary>
	/// <remarks>
	/// IMPORTANT: The TT_HoriHeader and TT_VertHeader structures should be
	/// identical except for the names of their fields which are different.
	/// 
	/// This ensures that a single function in the ‘ttload’ module is able to
	/// read both the horizontal and vertical headers.
	/// </remarks>
	public class VertHeader
	{
		internal IntPtr reference;
		internal VertHeaderRec rec;

		internal VertHeader(IntPtr reference)
		{
			this.reference = reference;
			this.rec = (VertHeaderRec)Marshal.PtrToStructure(reference, typeof(VertHeaderRec));
		}

		/// <summary>
		/// Gets the table version.
		/// </summary>
		public long Version
		{
			get
			{
				return rec.Version;
			}
		}

		/// <summary>
		/// Gest the font's ascender, i.e., the distance from the baseline to
		/// the top-most of all glyph points found in the font.
		/// 
		/// This value is invalid in many fonts, as it is usually set by the
		/// font designer, and often reflects only a portion of the glyphs
		/// found in the font (maybe ASCII).
		/// 
		/// You should use the ‘sTypoAscender’ field of the OS/2 table instead
		/// if you want the correct one.
		/// </summary>
		public short Ascender
		{
			get
			{
				return rec.Ascender;
			}
		}

		/// <summary>
		/// Gets the font's descender, i.e., the distance from the baseline to
		/// the bottom-most of all glyph points found in the font. It is
		/// negative.
		/// 
		/// This value is invalid in many fonts, as it is usually set by the
		/// font designer, and often reflects only a portion of the glyphs
		/// found in the font (maybe ASCII).
		/// 
		/// You should use the ‘sTypoDescender’ field of the OS/2 table instead
		/// if you want the correct one.
		/// </summary>
		public short Descender
		{
			get
			{
				return rec.Descender;
			}
		}

		/// <summary>
		/// Gets the font's line gap, i.e., the distance to add to the ascender and
		/// descender to get the BTB, i.e., the baseline-to-baseline distance
		/// for the font.
		/// </summary>
		public short LineGap
		{
			get
			{
				return rec.Line_Gap;
			}
		}

		/// <summary>
		/// Gets the maximum of all advance heights found in the font. It can
		/// be used to compute the maximum height of an arbitrary string of
		/// text.
		/// </summary>
		[CLSCompliant(false)]
		public ushort AdvanceHeightMax
		{
			get
			{
				return rec.advance_Height_Max;
			}
		}

		/// <summary>
		/// Gets the minimum top side bearing of all glyphs within the font.
		/// </summary>
		public short MinimumTopSideBearing
		{
			get
			{
				return rec.min_Top_Side_Bearing;
			}
		}

		/// <summary>
		/// Gets the minimum bottom side bearing of all glyphs within the font.
		/// </summary>
		public short MinimumBottomSideBearing
		{
			get
			{
				return rec.min_Bottom_Side_Bearing;
			}
		}

		/// <summary>
		/// Gets the maximum vertical extent (i.e., the ‘height’ of a glyph's
		/// bounding box) for all glyphs in the font.
		/// </summary>
		public short MaximumExtentY
		{
			get
			{
				return rec.yMax_Extent;
			}
		}

		/// <summary>
		/// Gets the rise coefficient of the cursor's slope of the cursor
		/// (slope=rise/run).
		/// </summary>
		public short CaretSlopeRise
		{
			get
			{
				return rec.caret_Slope_Rise;
			}
		}

		/// <summary>
		/// Gets the run coefficient of the cursor's slope.
		/// </summary>
		public short CaretSlopeRun
		{
			get
			{
				return rec.caret_Slope_Run;
			}
		}

		public short CaretOffset
		{
			get
			{
				return rec.caret_Offset;
			}
		}

		/// <summary>
		/// Gets the 8 reserved bytes.
		/// </summary>
		public short[] Reserved
		{
			get
			{
				return rec.Reserved;
			}
		}

		/// <summary>
		/// Gets 0, always.
		/// </summary>
		public short MetricDataFormat
		{
			get
			{
				return rec.metric_Data_Format;
			}
		}

		/// <summary>
		/// Number of VMetrics entries in the ‘vmtx’ table -- this value can be
		/// smaller than the total number of glyphs in the font.
		/// </summary>
		[CLSCompliant(false)]
		public ushort VMetricsCount
		{
			get
			{
				return rec.number_Of_VMetrics;
			}
		}

		/// <summary>
		/// A pointer into the ‘vmtx’ table.
		/// </summary>
		public IntPtr long_metrics
		{
			get
			{
				return rec.long_metrics;
			}
		}

		/// <summary>
		/// A pointer into the ‘vmtx’ table.
		/// </summary>
		public IntPtr short_metrics
		{
			get
			{
				return rec.short_metrics;
			}
		}
	}
}