﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;

namespace QLNSBV10
{
    public partial class fm_CHAM_CONG : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        XtraUserControl employeesUserControl;
        XtraUserControl customersUserControl;
        public fm_CHAM_CONG()
        {
            InitializeComponent();
            employeesUserControl = CreateUserControl("Employees");
            customersUserControl = CreateUserControl("Customers");
            accordionControl.SelectedElement = employeesAccordionControlElement;
        }
        XtraUserControl CreateUserControl(string text)
        {
            XtraUserControl result = new XtraUserControl();
            result.Name = text.ToLower() + "UserControl";
            result.Text = text;
            LabelControl label = new LabelControl();
            label.Parent = result;
            label.Appearance.Font = new Font("Tahoma", 25.25F);
            label.Appearance.ForeColor = Color.Gray;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.AutoSizeMode = LabelAutoSizeMode.None;
            label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            label.Text = text;
            return result;
        }
        void accordionControl_SelectedElementChanged(object sender, SelectedElementChangedEventArgs e)
        {
            if (e.Element == null) return;
            XtraUserControl userControl = e.Element.Text == "Employees" ? employeesUserControl : customersUserControl;
            tabbedView.AddDocument(userControl);
            tabbedView.ActivateDocument(userControl);
        }
        void barButtonNavigation_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Caption == "Employees") accordionControl.SelectedElement = employeesAccordionControlElement;
            else accordionControl.SelectedElement = customersAccordionControlElement;
        }
        void tabbedView_DocumentClosed(object sender, DocumentEventArgs e)
        {
            RecreateUserControls(e);
            SetAccordionSelectedElement(e);
        }
        void SetAccordionSelectedElement(DocumentEventArgs e)
        {
            if (tabbedView.Documents.Count != 0)
            {
                if (e.Document.Caption == "Employees") accordionControl.SelectedElement = customersAccordionControlElement;
                else accordionControl.SelectedElement = employeesAccordionControlElement;
            }
            else
            {
                accordionControl.SelectedElement = null;
            }
        }
        void RecreateUserControls(DocumentEventArgs e)
        {
            if (e.Document.Caption == "Employees") employeesUserControl = CreateUserControl("Employees");
            else customersUserControl = CreateUserControl("Customers");
        }

        private void fm_CHAM_CONG_Load(object sender, EventArgs e)
        {

        }

        private Form kiemtraton(Type type)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == type)
                {
                    return f;
                }
            }
            return null;
        }

        private void btn_chamcong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.kiemtraton(typeof());
            if(frm != null)
            {
                frm.Activate();
            }
        }


    }
}