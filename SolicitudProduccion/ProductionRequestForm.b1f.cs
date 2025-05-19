using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Xml;

namespace SolicitudProduccion
{
    [FormAttribute("SolicitudProduccion.ProductionRequestForm ", "ProductionRequestForm.b1f")]
    class ProductionRequestForm : UserFormBase
    {
        // Form Control Declarations
        private SAPbouiCOM.Button btnCreate;
        private SAPbouiCOM.ButtonCombo cbCopyTo;
        private SAPbouiCOM.Button btnCancel;
        private SAPbouiCOM.StaticText lblNoIte;
        private SAPbouiCOM.StaticText lblDesc;
        private SAPbouiCOM.StaticText lblQty;
        private SAPbouiCOM.StaticText lblWareH;
        private SAPbouiCOM.StaticText lblPrior;
        private SAPbouiCOM.EditText txtNoIte;
        private SAPbouiCOM.EditText txtDesc;
        private SAPbouiCOM.EditText txtQty;
        private SAPbouiCOM.EditText txtWareH;
        private SAPbouiCOM.EditText txtPrior;
        private SAPbouiCOM.Grid grdDet;
        private SAPbouiCOM.StaticText lblNoReq;
        private SAPbouiCOM.StaticText lblFecha;
        private SAPbouiCOM.StaticText lblUser;
        private SAPbouiCOM.StaticText lblLink;
        private SAPbouiCOM.StaticText lblLinkOr;
        private SAPbouiCOM.StaticText lblClient;
        private SAPbouiCOM.EditText txtNoReq;
        private SAPbouiCOM.EditText txtDate;
        private SAPbouiCOM.EditText txtLinkOr;
        private SAPbouiCOM.EditText txtClient;
        private SAPbouiCOM.ComboBox cbxLink;
        private SAPbouiCOM.StaticText lblComm;
        private SAPbouiCOM.EditText txtComm;
        private SAPbouiCOM.ComboBox cbxUser;

        // Form Initialization Methods
        public ProductionRequestForm()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form creation.
        /// </summary>
        public override void OnInitializeComponent()
        {
            //    Assigning controls from the form to variables for manipulation
            this.btnCreate = ((SAPbouiCOM.Button)(this.GetItem("btnCreate").Specific));
            this.cbCopyTo = ((SAPbouiCOM.ButtonCombo)(this.GetItem("cbCopyTo").Specific));
            this.btnCancel = ((SAPbouiCOM.Button)(this.GetItem("btnCancel").Specific));
            this.lblNoIte = ((SAPbouiCOM.StaticText)(this.GetItem("lblNoIte").Specific));
            this.lblDesc = ((SAPbouiCOM.StaticText)(this.GetItem("lblDesc").Specific));
            this.lblQty = ((SAPbouiCOM.StaticText)(this.GetItem("lblQty").Specific));
            this.lblWareH = ((SAPbouiCOM.StaticText)(this.GetItem("lblWareH").Specific));
            this.lblPrior = ((SAPbouiCOM.StaticText)(this.GetItem("lblPrior").Specific));
            this.txtNoIte = ((SAPbouiCOM.EditText)(this.GetItem("txtNoIte").Specific));
            this.txtDesc = ((SAPbouiCOM.EditText)(this.GetItem("txtDesc").Specific));
            this.txtQty = ((SAPbouiCOM.EditText)(this.GetItem("txtQty").Specific));
            this.txtWareH = ((SAPbouiCOM.EditText)(this.GetItem("txtWareH").Specific));
            this.txtPrior = ((SAPbouiCOM.EditText)(this.GetItem("txtPrior").Specific));
            this.grdDet = ((SAPbouiCOM.Grid)(this.GetItem("grdDet").Specific));
            this.lblNoReq = ((SAPbouiCOM.StaticText)(this.GetItem("lblNoReq").Specific));
            this.lblFecha = ((SAPbouiCOM.StaticText)(this.GetItem("lblDate").Specific));
            this.lblUser = ((SAPbouiCOM.StaticText)(this.GetItem("lblUser").Specific));
            this.lblLink = ((SAPbouiCOM.StaticText)(this.GetItem("lblLink").Specific));
            this.lblLinkOr = ((SAPbouiCOM.StaticText)(this.GetItem("lblLinkOr").Specific));
            this.lblClient = ((SAPbouiCOM.StaticText)(this.GetItem("lblClient").Specific));
            this.txtNoReq = ((SAPbouiCOM.EditText)(this.GetItem("txtNoReq").Specific));
            this.txtDate = ((SAPbouiCOM.EditText)(this.GetItem("txtDate").Specific));
            this.txtLinkOr = ((SAPbouiCOM.EditText)(this.GetItem("txtLinkOr").Specific));
            this.txtClient = ((SAPbouiCOM.EditText)(this.GetItem("txtClient").Specific));
            this.cbxLink = ((SAPbouiCOM.ComboBox)(this.GetItem("cbxLink").Specific));
            this.lblComm = ((SAPbouiCOM.StaticText)(this.GetItem("lblComm").Specific));
            this.txtComm = ((SAPbouiCOM.EditText)(this.GetItem("txtComm").Specific));
            this.cbCopyTo.ComboSelectAfter += this.cbCopyTo_ComboSelectAfter;
            this.cbxUser = ((SAPbouiCOM.ComboBox)(this.GetItem("cbxUser").Specific));
            this.OnCustomInitialize();
        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {

        } 

        private void OnCustomInitialize()  // Custom initialization when the form is loaded
        {
            this.btnCancel.PressedAfter += btnCancel_PressedAfter;
            this.btnCreate.PressedAfter += btnCreate_PressedAfter;
            
            this.cbCopyTo.ValidValues.Add("1", "Orden de fabricación");

            InitializeGrid();

            LoadUsersToComboBox(); // Fill user ComboBox
        }

        private void InitializeGrid() // Method to configure the initial structure of the grid
        {
            try
            {
                // Create an empty DataTable associated with the grid
                SAPbouiCOM.DataTable dataTable = this.UIAPIRawForm.DataSources.DataTables.Add("ProdRequestTable");

                // Define the columns of the DataTable (match the grid)
                dataTable.Columns.Add("U_ItemType", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 50); // Type
                dataTable.Columns.Add("U_ItemCode", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 100); // Item Number
                dataTable.Columns.Add("U_ItemName", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 100); // Description
                dataTable.Columns.Add("U_BaseQty", SAPbouiCOM.BoFieldsType.ft_Quantity, 0); // Base Quantity
                dataTable.Columns.Add("U_PlannedQty", SAPbouiCOM.BoFieldsType.ft_Quantity, 0); // Required Quantity
                dataTable.Columns.Add("U_wareHouse", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 50); // Warehouse
                dataTable.Columns.Add("U_IssueType", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 20); // Issue Method
                dataTable.Columns.Add("U_Costo_Inicial", SAPbouiCOM.BoFieldsType.ft_Price, 0); // Initial Cost
                dataTable.Columns.Add("U_Costo_Inicial2", SAPbouiCOM.BoFieldsType.ft_Price, 0); // Initial Cost 2

                // Add an initial empty row
                dataTable.Rows.Add(1);

                // Assign the DataTable to the grid
                this.grdDet.DataTable = dataTable;

                // Configure column headers
                this.grdDet.Columns.Item("U_ItemType").TitleObject.Caption = "Tipo";
                this.grdDet.Columns.Item("U_ItemCode").TitleObject.Caption = "Nº del artículo";
                this.grdDet.Columns.Item("U_ItemName").TitleObject.Caption = "Descripción";
                this.grdDet.Columns.Item("U_BaseQty").TitleObject.Caption = "Cantidad base";
                this.grdDet.Columns.Item("U_PlannedQty").TitleObject.Caption = "Cantidad requerida";
                this.grdDet.Columns.Item("U_wareHouse").TitleObject.Caption = "Almacén";
                this.grdDet.Columns.Item("U_IssueType").TitleObject.Caption = "Método de emisión";
                this.grdDet.Columns.Item("U_Costo_Inicial").TitleObject.Caption = "Costo inicial";
                this.grdDet.Columns.Item("U_Costo_Inicial2").TitleObject.Caption = "Costo inicial 2";
            }
            catch (Exception ex)
            {
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox($"Error al preparar el Grid: {ex.Message}");
            }
        }


        // Data Loading Methods
        private void LoadUsersToComboBox()
        {
            try
            {
                // Get DI API company object
                SAPbobsCOM.Company company = (SAPbobsCOM.Company)SAPbouiCOM.Framework.Application.SBO_Application.Company.GetDICompany();

                // Get recordset object
                SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                // Query to get active users (not locked)
                oRS.DoQuery(@"SELECT ""USERID"", ""U_NAME"" FROM OUSR WHERE ""Locked"" = 'N'");

                // Clear previous values
                for (int i = this.cbxUser.ValidValues.Count - 1; i >= 0; i--)
                {
                    this.cbxUser.ValidValues.Remove(i, SAPbouiCOM.BoSearchKey.psk_Index);
                }

                // Fill ComboBox with USERID as value, U_NAME as display text
                while (!oRS.EoF)
                {
                    string userId = oRS.Fields.Item("USERID").Value.ToString();
                    string userName = oRS.Fields.Item("U_NAME").Value.ToString();
                    this.cbxUser.ValidValues.Add(userId, userName);
                    oRS.MoveNext();
                }

                // Get the current logged-in user's code (ID)
                string currentUserId = company.UserSignature.ToString();

                // Select the current user in the ComboBox by USERID
                this.cbxUser.Select(currentUserId, SAPbouiCOM.BoSearchKey.psk_ByValue);
            }
            catch (Exception ex)
            {
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox($"Error loading users: {ex.Message}");
            }
        }


        // UI Event Handlers
        private void cbCopyTo_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal) // Event when an option is selected in the "Copy To" ComboBox
        {
            try
            {
                if (this.cbCopyTo.Selected.Value == "1")
                {
                    OpenProductionOrderForm();
                }
            }
            catch (Exception ex)
            {
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox($"Error: {ex.Message}");
            }
        }

        private void btnCancel_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal) // Event when the "Cancel" button is pressed
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

        private void btnCreate_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal) // Method executed when the Create button is pressed
        {
            try
            {
                CreateProductionRequest();
            }
            catch (Exception ex)
            {
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox($"Error al crear la solicitud de producción: {ex.Message}");
            }
        }


        // Business Logic Methods
        private void CreateProductionRequest() // Method to create Production Request
        {
            try
            {
                // Get the SAP CompanyService object
                SAPbobsCOM.CompanyService companyService = ((SAPbobsCOM.Company)SAPbouiCOM.Framework.Application.SBO_Application.Company.GetDICompany()).GetCompanyService();

                // Get the GeneralService for the header table (@SOLI_PROD_ENC)
                SAPbobsCOM.GeneralService generalService = companyService.GetGeneralService("\"SOLI_PROD_ENC\"");

                // Create a GeneralData object for the header
                SAPbobsCOM.GeneralData headerData = (SAPbobsCOM.GeneralData)generalService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralData);

                // Fill header fields
                headerData.SetProperty("U_ItemCode", txtNoIte);
                headerData.SetProperty("U_ProdName", txtDesc);
                headerData.SetProperty("U_PlannedQty", txtQty);
                headerData.SetProperty("U_Warehouse", txtWareH);
                headerData.SetProperty("U_Priority", txtPrior);
                headerData.SetProperty("U_PostDate", txtDate.Value);
                headerData.SetProperty("U_LinkToObj", cbxLink.Value);
                headerData.SetProperty("U_OriginNum", txtLinkOr.Value);
                headerData.SetProperty("U_Client", txtClient.Value);
                headerData.SetProperty("U_Comments", txtComm.Value);

                // Get the child collection for the detail table (@SOLI_PROD_DET)
                SAPbobsCOM.GeneralDataCollection detailsCollection = headerData.Child("\"@SOLI_PROD_DET\"");

                // Loop through the grid rows and add them to the details collection
                for (int i = 0; i < grdDet.Rows.Count; i++)
                {
                    // Create a new record in the details collection
                    SAPbobsCOM.GeneralData detailData = detailsCollection.Add();

                    // Fill detail fields
                    detailData.SetProperty("U_ItemType", grdDet.DataTable.GetValue("U_ItemType", i).ToString());
                    detailData.SetProperty("U_ItemCode", grdDet.DataTable.GetValue("U_ItemCode", i).ToString());
                    detailData.SetProperty("U_ItemName", grdDet.DataTable.GetValue("U_ItemName", i).ToString());
                    detailData.SetProperty("U_BaseQty", Convert.ToDouble(grdDet.DataTable.GetValue("U_BaseQty", i)));
                    detailData.SetProperty("U_PlannedQty", Convert.ToDouble(grdDet.DataTable.GetValue("U_PlannedQty", i)));
                    detailData.SetProperty("U_wareHouse", grdDet.DataTable.GetValue("U_wareHouse", i).ToString());
                    detailData.SetProperty("U_IssueType", grdDet.DataTable.GetValue("U_IssueType", i).ToString());
                    detailData.SetProperty("U_Costo_Inicial", Convert.ToDouble(grdDet.DataTable.GetValue("U_Costo_Inicial", i)));
                    detailData.SetProperty("U_Costo_Inicial2", Convert.ToDouble(grdDet.DataTable.GetValue("U_Costo_Inicial2", i)));
                }

                // Add the header and details to the database
                generalService.Add(headerData);

                // Notify the user of success
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox("Solicitud de producción creada con éxito.");
            }
            catch (Exception ex)
            {
                // Notify the user of any error
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox($"Ocurrió un error: {ex.Message}");
            }
        }

        private void OpenProductionOrderForm() // Method to open the Production Order form
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
    }
}