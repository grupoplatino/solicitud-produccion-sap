using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Xml;

namespace SolicitudProduccion
{
    [FormAttribute("SolicitudProduccion.Form1", "Form1.b1f")]
    class Form1 : UserFormBase
    {
        public Form1()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("btnCrear").Specific));
            this.cbCopiarA = ((SAPbouiCOM.ButtonCombo)(this.GetItem("cbCopiarA").Specific));
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("btnCancel").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("lblNoPro").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("lblDesc").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("lblCant").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("lblAlm").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("lblPrior").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("txtNoPro").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("txtDesc").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("txtCant").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("txtAlm").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("txtPrior").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_17").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("lblNoSol").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("lblFecha").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("lblUsua").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("lblVin").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("lblPeVin").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("lblClient").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("txtNoSol").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("txtFecha").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("txtUsua").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("txtNorma").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("txtPeVin").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("txtClient").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("lblNorma").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("lblProy").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("txtProy").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("cbxVin").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("lblComm").Specific));
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("txtComm").Specific));
            this.cbCopiarA.ComboSelectAfter += this.cbCopiarA_ComboSelectAfter;
            this.OnCustomInitialize();

        }

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.ButtonCombo cbCopiarA;
        private SAPbouiCOM.Button btnCancel;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.EditText EditText11;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.EditText EditText12;

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {

        }

        private void OnCustomInitialize()
        {
            this.btnCancel.PressedAfter += btnCancel_PressedAfter;
            this.cbCopiarA.ValidValues.Add("1", "Orden de fabricación");
        }

        private void cbCopiarA_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (this.cbCopiarA.Selected.Value == "1")
                {
                    OpenProductionOrderForm();
                }
            }
            catch (Exception ex)
            {
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox($"Error: {ex.Message}");
            }
        }

        private void OpenProductionOrderForm()
        {
            try
            {
                SAPbouiCOM.Framework.Application.SBO_Application.OpenForm(
                    SAPbouiCOM.BoFormObjectEnum.fo_ProductionOrder,
                    "",
                    ""
                );
            }
            catch (Exception ex)
            {
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox($"Error al abrir el formulario: {ex.Message}");
            }
        }

        private void btnCancel_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                this.UIAPIRawForm.Close();
            }
            catch (Exception ex)
            {
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox($"Error al cerrar el formulario: {ex.Message}");
            }
        }
    }
}