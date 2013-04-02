using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Gizmox.WebGUI.Forms;
using AppGest.Util;

namespace AppGest.Vista.Controles
{

    public class CalendarColumn : DataGridViewColumn
    {

        public static string EDIT_FORMAT = FormatHelper.ShortDateFormatCurrentCulture;

        public CalendarColumn()
            : base(new CalendarCell())
        {

        }

        public override DataGridViewCell CellTemplate
        {



            get { return base.CellTemplate; }


            set
            {

                if ((value != null) && !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");

                }

                base.CellTemplate = value;
            }
        }

        public object EditFormat
        {
            get { return EDIT_FORMAT; }
            set { EDIT_FORMAT = value as string; }
        }

    }

    public class CalendarCell : Gizmox.WebGUI.Forms.DataGridViewTextBoxCell
    {

        public CalendarCell()
        {
            this.Style.Format = CalendarColumn.EDIT_FORMAT;
        }




        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            CalendarEditingControl ctl = (CalendarEditingControl)DataGridView.EditingControl;
            ctl.Value = (DateTime) (this.Value ?? DateTime.Now);
        }



        public override Type EditType
        {
            get { return typeof(CalendarEditingControl); }
        }

        public override Type ValueType
        {
            get { return typeof(DateTime); }
        }

        public override object DefaultNewRowValue
        {
            get { return DateTime.Now; }
        }
    }

    class CalendarEditingControl : Gizmox.WebGUI.Forms.DateTimePicker, Gizmox.WebGUI.Forms.IDataGridViewEditingControl
    {

        private Gizmox.WebGUI.Forms.DataGridView dataGridViewControl;
        private bool valueIsChanged = false;
        private int rowIndexNum;

        public CalendarEditingControl()
        {
            this.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.CustomFormat = CalendarColumn.EDIT_FORMAT;
        }

        public object EditingControlFormattedValue
        {

            get { return this.Value.ToString(CalendarColumn.EDIT_FORMAT); }

            set
            {
                if (value is string)
                    this.Value = DateTime.ParseExact(value.ToString(), CalendarColumn.EDIT_FORMAT, null);
            }
        }

        public object GetEditingControlFormattedValue(Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts context)
        {
            return this.Value.ToString(CalendarColumn.EDIT_FORMAT);
        }

        public void ApplyCellStyleToEditingControl(Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BorderColor = dataGridViewCellStyle.BackColor;
        }

        public int EditingControlRowIndex
        {
            get { return rowIndexNum; }
            set { rowIndexNum = value; }
        }

        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public Gizmox.WebGUI.Forms.DataGridView EditingControlDataGridView
        {
            get { return dataGridViewControl; }
            set { dataGridViewControl = value; }
        }

        public bool EditingControlValueChanged
        {
            get { return valueIsChanged; }
            set { valueIsChanged = value; }
        }

        public Cursor EditingControlCursor
        {
            get { return base.Cursor; }
        }
        Cursor Gizmox.WebGUI.Forms.IDataGridViewEditingControl.EditingPanelCursor
        {
            get { return EditingControlCursor; }
        }
        protected override void OnValueChanged(EventArgs eventargs)
        {
            valueIsChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
}