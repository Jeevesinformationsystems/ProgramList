﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Xml;
using Telerik.Windows.Controls;

namespace ScrollIntoViewAsyncMvvm
{
    public sealed class DateTimeColumnInfo : GridViewDataColumn
    {
        public DateTimeColumnInfo(string header)
        {
            CellEditTemplate = GetCellEditTemplate(header);
            //CellTemplate = CellEditTemplate;
        }

        private static DataTemplate GetCellEditTemplate(string bindingProperty)
        {
            var strTemplate = $@"
                <DataTemplate 
                    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                    xmlns:telerik=""http://schemas.telerik.com/2008/xaml/presentation""
                    >

                    <telerik:RadDateTimePicker TimeInterval=""00:15""
                        ParseExact = ""True""
                        InputMode =""DatePicker"" 
                        SelectedValue=""{{ Binding {bindingProperty}, Mode = TwoWay }}""
                    />
                </DataTemplate>
            ";
            using (var stringReader = new StringReader(strTemplate))
            {
                {
                    var xmlReader = XmlReader.Create(stringReader);
                    return XamlReader.Load(xmlReader) as DataTemplate;
                }
            }
            //ToDo use convertors and datetime objects use  ToShortTimeString, ToShortDateString

        }
    }
}
