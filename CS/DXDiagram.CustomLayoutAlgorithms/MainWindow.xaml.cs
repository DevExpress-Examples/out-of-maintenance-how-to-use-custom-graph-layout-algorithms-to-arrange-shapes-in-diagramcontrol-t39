using MsaglHelpers;
using DevExpress.Xpf.Ribbon;
using DevExpress.Diagram.Core;
using DevExpress.Diagram.Core.Layout;
using System.Linq;
using DevExpress.Mvvm.Native;
using DevExpress.Xpf.Core;
using System;

namespace DXDiagram.CustomLayoutAlgorithms {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXRibbonWindow {
        public MainWindow() {
            InitializeComponent();
        }

        void LoadSugiyama(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            diagramControl.LoadDocument("Data/SugiyamaLayout.xml");
        }

        void ApplySugiyama(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            ApplyLayout(new GraphLayout(new SugiyamaLayoutCalculator()));
        }
        void LoadDisconnectedGraphs(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            diagramControl.LoadDocument("Data/DisconnectedGraphs.xml");
        }

        void ApplyDisconnectedGraphs(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            ApplyLayout(new GraphLayout(new DisconnectedGraphsLayoutCalculator()));
        }

        void LoadPhyloTree(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            diagramControl.LoadDocument("Data/PhyloTree.xml");
        }

        void ApplyPhyloTree(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            ApplyLayout(new PhyloTreeLayout(new PhyloTreeLayoutCalculator()));
        }
        void LoadRanking(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            diagramControl.LoadDocument("Data/RankingLayout.xml");
        }

        void ApplyRanking(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            ApplyLayout(new GraphLayout(new RankingLayoutCalculator()));
        }
        void LoadMDS(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            diagramControl.LoadDocument("Data/MDSLayout.xml");
        }

        void ApplyMDS(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
            ApplyLayout(new GraphLayout(new MDSLayoutCalculator()));
        }

        void ApplyLayout(GraphLayout layout) {
            try {
                diagramControl.RelayoutDiagramItems(layout.RelayoutGraphNodesPosition(GraphOperations.GetDiagramGraph(diagramControl)));
                diagramControl.Items.OfType<IDiagramConnector>().ForEach(connector => { connector.Type = layout.GetDiagramConnectorType(); connector.UpdateRoute(); });
                diagramControl.FitToDrawing();
            } catch(Exception e) {
                    DXMessageBox.Show(string.Format("Error message: '{0}'", e.Message), "Error has been occurred");
            }
        }
    }
}