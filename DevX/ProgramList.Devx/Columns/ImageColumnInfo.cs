﻿using DevExpress.Xpf.Grid;
using ProgramList.Common.Models;
using System;

namespace ProgramList.DevX.Columns
{
    public sealed class ImageColumnInfo: ColumnInfo
    {
        public ImageColumnInfo(string header, Type dataType, bool isVisible, bool isReadOnly, bool isEnabled, bool isSelected, bool isLinked)
            :base(header, dataType, isVisible, isReadOnly, isEnabled, isSelected, isLinked)
        {
            //this.ApplyDefaultSettings(header, dataType, isVisible, isReadOnly, isEnabled, isSelected);
            //ImageStretch = System.Windows.Media.Stretch.None;
            //ImageWidth = 50;
            //ImageHeight = 50;
        }
    }
}
