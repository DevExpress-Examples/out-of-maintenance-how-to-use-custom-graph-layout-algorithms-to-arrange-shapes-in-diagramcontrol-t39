using DevExpress.Diagram.Core;
using DevExpress.Diagram.Core.Layout;
using DevExpress.Mvvm.Native;
using MsaglHelpers;
using System.Linq;
using System.Windows;

namespace DXDiagram.CustomLayoutAlgorithms {
    /// <summary>
    /// Interaction logic for LayoutExampleWindow.xaml
    /// </summary>
    public partial class LayoutExampleWindow : Window {
        readonly GraphLayout layout;
        readonly string sourceGraphPath;

        public LayoutExampleWindow(GraphLayout layout, string sourceGraphPath) {
            InitializeComponent();
            this.layout = layout;
            this.sourceGraphPath = sourceGraphPath;
            Loaded += OnLoaded;
        }
        void OnLoaded(object sender, RoutedEventArgs e) {
            diagramControl.LoadDocument(sourceGraphPath);
        }
        void RelayoutDiagramItem(object sender, RoutedEventArgs e) {
            diagramControl.RelayoutDiagramItems(layout.RelayoutGraphNodesPosition(GraphOperations.GetDiagramGraph(diagramControl)));

            diagramControl.Controller.RegisterRoutingStrategy(layout.GetDiagramConnectorType(), layout.GetDiagramRoutingStrategy());

            diagramControl.Items.OfType<IDiagramConnector>().ForEach(connector => { connector.Type = layout.GetDiagramConnectorType(); connector.UpdateRoute(); });

            diagramControl.FitToDrawing();
        }
    }
}