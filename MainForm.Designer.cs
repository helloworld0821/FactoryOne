namespace FactoryOne
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnReadTracer = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnGetLayer = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSLBH = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnFacAna = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnYJCS = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSJCS = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockDate = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbEndDate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbStartDate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnDate = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockDate.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barBtnReadTracer,
            this.barBtnGetLayer,
            this.barBtnSLBH,
            this.barBtnFacAna,
            this.barBtnYJCS,
            this.barBtnSJCS});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(900, 147);
            // 
            // barBtnReadTracer
            // 
            this.barBtnReadTracer.Caption = "读取示踪剂文件";
            this.barBtnReadTracer.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnReadTracer.Glyph")));
            this.barBtnReadTracer.Id = 1;
            this.barBtnReadTracer.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnReadTracer.LargeGlyph")));
            this.barBtnReadTracer.Name = "barBtnReadTracer";
            this.barBtnReadTracer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnReadTracer_ItemClick);
            // 
            // barBtnGetLayer
            // 
            this.barBtnGetLayer.Caption = "获取产量下降影响较大的层";
            this.barBtnGetLayer.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnGetLayer.Glyph")));
            this.barBtnGetLayer.Id = 2;
            this.barBtnGetLayer.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnGetLayer.LargeGlyph")));
            this.barBtnGetLayer.Name = "barBtnGetLayer";
            this.barBtnGetLayer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnGetLayer_ItemClick);
            // 
            // barBtnSLBH
            // 
            this.barBtnSLBH.Caption = "分析来水量变化";
            this.barBtnSLBH.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnSLBH.Glyph")));
            this.barBtnSLBH.Id = 3;
            this.barBtnSLBH.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnSLBH.LargeGlyph")));
            this.barBtnSLBH.Name = "barBtnSLBH";
            this.barBtnSLBH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSLBH_ItemClick);
            // 
            // barBtnFacAna
            // 
            this.barBtnFacAna.Caption = "影响因素分析";
            this.barBtnFacAna.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnFacAna.Glyph")));
            this.barBtnFacAna.Id = 4;
            this.barBtnFacAna.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnFacAna.LargeGlyph")));
            this.barBtnFacAna.Name = "barBtnFacAna";
            this.barBtnFacAna.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnFacAna_ItemClick);
            // 
            // barBtnYJCS
            // 
            this.barBtnYJCS.Caption = "油井措施";
            this.barBtnYJCS.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnYJCS.Glyph")));
            this.barBtnYJCS.Id = 5;
            this.barBtnYJCS.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnYJCS.LargeGlyph")));
            this.barBtnYJCS.Name = "barBtnYJCS";
            this.barBtnYJCS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnYJCS_ItemClick);
            // 
            // barBtnSJCS
            // 
            this.barBtnSJCS.Caption = "水井措施";
            this.barBtnSJCS.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnSJCS.Glyph")));
            this.barBtnSJCS.Id = 6;
            this.barBtnSJCS.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnSJCS.LargeGlyph")));
            this.barBtnSJCS.Name = "barBtnSJCS";
            this.barBtnSJCS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSJCS_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnReadTracer);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnGetLayer);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnSLBH);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnFacAna);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnYJCS);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnSJCS);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockDate});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // dockDate
            // 
            this.dockDate.Controls.Add(this.dockPanel1_Container);
            this.dockDate.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dockDate.ID = new System.Guid("8d138bf6-8cfd-4f93-a986-2ff9c632ac0a");
            this.dockDate.Location = new System.Drawing.Point(0, 147);
            this.dockDate.Name = "dockDate";
            this.dockDate.OriginalSize = new System.Drawing.Size(200, 107);
            this.dockDate.Size = new System.Drawing.Size(900, 107);
            this.dockDate.Text = "日期选择";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.labelControl2);
            this.dockPanel1_Container.Controls.Add(this.labelControl1);
            this.dockPanel1_Container.Controls.Add(this.cmbEndDate);
            this.dockPanel1_Container.Controls.Add(this.cmbStartDate);
            this.dockPanel1_Container.Controls.Add(this.btnDate);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(892, 80);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(411, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "结束日期";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(100, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "起始日期";
            // 
            // cmbEndDate
            // 
            this.cmbEndDate.Location = new System.Drawing.Point(485, 28);
            this.cmbEndDate.MenuManager = this.ribbonControl1;
            this.cmbEndDate.Name = "cmbEndDate";
            this.cmbEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEndDate.Size = new System.Drawing.Size(100, 20);
            this.cmbEndDate.TabIndex = 2;
            // 
            // cmbStartDate
            // 
            this.cmbStartDate.Location = new System.Drawing.Point(176, 28);
            this.cmbStartDate.MenuManager = this.ribbonControl1;
            this.cmbStartDate.Name = "cmbStartDate";
            this.cmbStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStartDate.Size = new System.Drawing.Size(100, 20);
            this.cmbStartDate.TabIndex = 1;
            // 
            // btnDate
            // 
            this.btnDate.Location = new System.Drawing.Point(664, 28);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(75, 23);
            this.btnDate.TabIndex = 0;
            this.btnDate.Text = "确定";
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 254);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(900, 246);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dockDate);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockDate.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barBtnReadTracer;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockDate;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbEndDate;
        private DevExpress.XtraEditors.ComboBoxEdit cmbStartDate;
        private DevExpress.XtraEditors.SimpleButton btnDate;
        private DevExpress.XtraBars.BarButtonItem barBtnGetLayer;
        private DevExpress.XtraBars.BarButtonItem barBtnSLBH;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem barBtnFacAna;
        private DevExpress.XtraBars.BarButtonItem barBtnYJCS;
        private DevExpress.XtraBars.BarButtonItem barBtnSJCS;
    }
}

