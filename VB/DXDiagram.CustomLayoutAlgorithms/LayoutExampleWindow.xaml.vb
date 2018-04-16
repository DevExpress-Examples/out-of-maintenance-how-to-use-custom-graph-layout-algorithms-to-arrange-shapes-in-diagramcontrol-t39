Imports DevExpress.Diagram.Core
Imports DevExpress.Diagram.Core.Layout
Imports DevExpress.Mvvm.Native
Imports MsaglHelpers
Imports System.Linq
Imports System.Windows

Namespace DXDiagram.CustomLayoutAlgorithms
    ''' <summary>
    ''' Interaction logic for LayoutExampleWindow.xaml
    ''' </summary>
    Partial Public Class LayoutExampleWindow
        Inherits Window

        Private ReadOnly layout As GraphLayout
        Private ReadOnly sourceGraphPath As String

        Public Sub New(ByVal layout As GraphLayout, ByVal sourceGraphPath As String)
            InitializeComponent()
            Me.layout = layout
            Me.sourceGraphPath = sourceGraphPath
            AddHandler Loaded, AddressOf OnLoaded
        End Sub
        Private Sub OnLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            diagramControl.LoadDocument(sourceGraphPath)
        End Sub
        Private Sub RelayoutDiagramItem(ByVal sender As Object, ByVal e As RoutedEventArgs)
            diagramControl.RelayoutDiagramItems(layout.RelayoutGraphNodesPosition(GraphOperations.GetDiagramGraph(diagramControl)))

            diagramControl.Controller.RegisterRoutingStrategy(layout.GetDiagramConnectorType(), layout.GetDiagramRoutingStrategy())

            diagramControl.Items.OfType(Of IDiagramConnector)().ForEach(Sub(connector)
                connector.Type = layout.GetDiagramConnectorType()
                connector.UpdateRoute()
            End Sub)

            diagramControl.FitToDrawing()
        End Sub
    End Class
End Namespace