﻿using ProgramList.Common.DynamicType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgramList.Common.Models
{
    public class ListItemBase : RunTimeModelBase, ICustomisation
    {
        private IList<IColumnInfo> _columns;
        private Dictionary<string, CellInfo> _cellInfoList;

        private int _rowNumber = -1;
        public int RowNumber
        {
            get
            {
                return _rowNumber;
            }
            private set
            {
                SetProperty(ref _rowNumber, value);
            }
        }

        private string _background;
        public string Background
        {
            get
            {
                return _background;
            }
            set
            {
                SetProperty(ref _background, value);
            }
        }

        private string _foreground;
        public string Foreground
        {
            get
            {
                return _foreground;
            }
            set
            {
                SetProperty(ref _foreground, value);
            }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                SetProperty(ref _isEnabled, value);
            }
        }

        private bool _isReadOnly = false;
        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }
            set
            {
                SetProperty(ref _isReadOnly, value);
            }
        }

        private bool _isInEditMode;
        public bool IsInEditMode
        {
            get
            {
                return _isInEditMode;
            }
            set
            {
                SetProperty(ref _isInEditMode, value);
            }
        }


        private bool _isCurrent;
        public bool IsCurrent
        {
            get
            {
                return _isCurrent;
            }
            set
            {
                SetProperty(ref _isCurrent, value);
            }
        }


        public ListItemBase(IList<IColumnInfo> columns, int rowNumber) : base(new Dictionary<string, object>(columns.Count))
        {
            _columns = columns;
            _rowNumber = rowNumber;
            _cellInfoList = new Dictionary<string, CellInfo>(_columns.Count);
            
            foreach (var column in _columns)
            {
                _cellInfoList.Add(column.UniqueName, new CellInfo(column.UniqueName, this, false));
            }

        }

        public string GetForeground(string propertyName)
        {
            if (_cellInfoList.ContainsKey(propertyName))
                return _cellInfoList[propertyName].Foreground;

            return null;
        }

        public void SetForeground(string foreground, string propertyName)
        {
            if (_cellInfoList.ContainsKey(propertyName))
            {
                var cellProperties = _cellInfoList[propertyName];
                if (cellProperties.Foreground == foreground)
                    return;
                _cellInfoList[propertyName].Foreground = foreground;
                OnPropertyChanged(propertyName);
            }

        }

        public string GetBackground(string propertyName)
        {
            if (_cellInfoList.ContainsKey(propertyName))
                return _cellInfoList[propertyName].Background;

            return null;
        }

        public void SetBackground(string background, string propertyName)
        {
            if (_cellInfoList.ContainsKey(propertyName))
            {
                var cellProperties = _cellInfoList[propertyName];
                if (cellProperties.Background == background)
                    return;
                _cellInfoList[propertyName].Background = background;
                OnPropertyChanged(propertyName);
            }

        }

        public bool GetIsEnabled(string propertyName)
        {
            if (_cellInfoList.ContainsKey(propertyName))
                return _cellInfoList[propertyName].IsEnabled;

            return true;
        }

        public void SetIsEnabled(bool isEnabled, string propertyName)
        {
            if (_cellInfoList.ContainsKey(propertyName))
            {
                var cellProperties = _cellInfoList[propertyName];
                if (cellProperties.IsEnabled == isEnabled)
                    return;
                _cellInfoList[propertyName].IsEnabled = isEnabled;
                OnPropertyChanged(propertyName);
            }

        }

        public bool GetIsReadOnly(string propertyName)
        {
            if (_cellInfoList.ContainsKey(propertyName))
                return _cellInfoList[propertyName].IsReadOnly;

            return true;
        }

        public void SetIsReadOnly(bool isReadOnly, string propertyName)
        {
            if (_cellInfoList.ContainsKey(propertyName))
            {
                var cellProperties = _cellInfoList[propertyName];
                if (cellProperties.IsReadOnly == isReadOnly)
                    return;
                _cellInfoList[propertyName].IsReadOnly = isReadOnly;
                OnPropertyChanged(propertyName);
            }

        }

        public bool GetIsInEditMode(string propertyName)
        {
            if (_cellInfoList.ContainsKey(propertyName))
                return _cellInfoList[propertyName].IsInEditMode;

            return true;
        }

        public void SetIsInEditMode(bool isInEditMode, string propertyName)
        {
            if (_cellInfoList.ContainsKey(propertyName))
            {
                var cellProperties = _cellInfoList[propertyName];
                if (cellProperties.IsInEditMode == isInEditMode)
                    return;
                _cellInfoList[propertyName].IsInEditMode = isInEditMode;
                OnPropertyChanged(propertyName);
            }

        }

        public bool GetIsCurrent(string propertyName)
        {
            if (_cellInfoList.ContainsKey(propertyName))
                return _cellInfoList[propertyName].IsCurrent;

            return true;
        }

        public void SetIsCurrent(bool isCurrent, string propertyName)
        {
            if (_cellInfoList.ContainsKey(propertyName))
            {
                var cellProperties = _cellInfoList[propertyName];
                if (cellProperties.IsCurrent == isCurrent)
                    return;
                _cellInfoList[propertyName].IsCurrent = isCurrent;
                OnPropertyChanged(propertyName);
            }

        }


        private static string GetPropertyName(string caller)
        {
            return caller.Substring(caller.IndexOf('_') + 1);
        }





        public string GetForegroundInternal(string caller)
        {
            return GetForeground(GetPropertyName(caller));
        }

        public void SetForegroundInternal(string foreground, string caller)
        {
            SetForeground(foreground, GetPropertyName(caller));
        }
        public string GetBackgroundInternal(string caller)
        {
            return GetBackground(GetPropertyName(caller));
        }

        public void SetBackgroundInternal(string background, string caller)
        {
            SetBackground(background, GetPropertyName(caller));
        }

        protected bool GetIsEnabledInternal([CallerMemberName]string caller = "")
        {
            return GetIsEnabled(GetPropertyName(caller));
        }

        protected void SetIsEnabledInternal(bool isEnabled, [CallerMemberName] string caller = "")
        {
            SetIsEnabled(isEnabled, GetPropertyName(caller));
        }
        protected bool GetIsReadOnlyInternal(string caller)
        {
            return GetIsReadOnly(GetPropertyName(caller));
        }

        protected void SetIsReadOnlyInternal(bool isReadOnly, string caller)
        {
            SetIsReadOnly(isReadOnly, GetPropertyName(caller));
        }
        protected bool GetIsInEditModeInternal(string caller)
        {
            return GetIsInEditMode(GetPropertyName(caller));
        }

        protected void SetIsInEditModeInternal(bool isInEditMode, string caller)
        {
            SetIsInEditMode(isInEditMode, GetPropertyName(caller));
        }
        protected bool GetIsCurrentInternal(string caller)
        {
            return GetIsCurrent(GetPropertyName(caller));
        }

        protected void SetIsCurrentInternal(bool isCurrent, string caller)
        {
            SetIsCurrent(isCurrent, GetPropertyName(caller));
        }

    }
}
