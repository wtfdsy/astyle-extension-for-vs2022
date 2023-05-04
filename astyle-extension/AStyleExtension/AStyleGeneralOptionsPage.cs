﻿using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AStyleExtension
{
    [CLSCompliant(false), ComVisible(true)]
    public class AStyleGeneralOptionsPage : DialogPage
    {
        private AStyleGeneralOptionsControl _control;

        public string CppOptions { get; set; }
        public string CsOptions { get; set; }
        public bool CppFormatOnSave { get; set; }
        public bool CsFormatOnSave { get; set; }
        public bool IsCSarpEnabled { get; set; }

        public AStyleGeneralOptionsPage()
        {
            IsCSarpEnabled = true;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override IWin32Window Window
        {
            get
            {
                _control = new AStyleGeneralOptionsControl();

                if (CppOptions != null)
                {
                    _control.CppOptions = CppOptions;
                }

                if (CsOptions != null)
                {
                    _control.CsOptions = CsOptions;
                }

                _control.IsCSarpEnabled = IsCSarpEnabled;
                _control.CppFormatOnSave = CppFormatOnSave;
                _control.CsFormatOnSave = CsFormatOnSave;

                return _control;
            }
        }

        protected override void OnDeactivate(CancelEventArgs e)
        {
            if (_control != null)
            {
                CppOptions = _control.CppOptions;
                CsOptions = _control.CsOptions;
                CppFormatOnSave = _control.CppFormatOnSave;
                CsFormatOnSave = _control.CsFormatOnSave;
            }

            base.OnDeactivate(e);
        }

        protected override void OnActivate(CancelEventArgs e)
        {
            if (_control != null)
            {
                _control.CppOptions = CppOptions;
                _control.CsOptions = CsOptions;
                _control.CppFormatOnSave = CppFormatOnSave;
                _control.CsFormatOnSave = CsFormatOnSave;

                _control.ClearDetails();
            }

            base.OnActivate(e);
        }

        protected override void OnApply(PageApplyEventArgs e)
        {
            if (_control != null)
            {
                CppOptions = _control.CppOptions;
                CsOptions = _control.CsOptions;
                CppFormatOnSave = _control.CppFormatOnSave;
                CsFormatOnSave = _control.CsFormatOnSave;
            }

            base.OnApply(e);
        }
    }
}
