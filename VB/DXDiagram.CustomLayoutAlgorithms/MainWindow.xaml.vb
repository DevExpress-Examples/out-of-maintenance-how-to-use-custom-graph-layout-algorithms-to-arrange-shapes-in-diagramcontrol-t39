Imports MsaglHelpers
Imports DevExpress.Xpf.Ribbon
Imports DevExpress.Diagram.Core
Imports DevExpress.Diagram.Core.Layout
Imports System.Linq
Imports DevExpress.Mvvm.Native
Imports DevExpress.Xpf.Core
Imports System

Namespace DXDiagram.CustomLayoutAlgorithms
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits DXRibbonWindow

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub LoadSugiyama(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            diagramControl.LoadDocument("Data/SugiyamaLayout.xml")
        End Sub

        Private Sub ApplySugiyama(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            ApplyLayout(New GraphLayout(New SugiyamaLayoutCalculator()))
        End Sub
        Private Sub LoadDisconnectedGraphs(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            diagramControl.LoadDocument("Data/DisconnectedGraphs.xml")
        End Sub

        Private Sub ApplyDisconnectedGraphs(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            ApplyLayout(New GraphLayout(New DisconnectedGraphsLayoutCalculator()))
        End Sub

        Private Sub LoadPhyloTree(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            diagramControl.LoadDocument("Data/PhyloTree.xml")
        End Sub

        Private Sub ApplyPhyloTree(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            ApplyLayout(New PhyloTreeLayout(New PhyloTreeLayoutCalculator()))
        End Sub
        Private Sub LoadRanking(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            diagramControl.LoadDocument("Data/RankingLayout.xml")
        End Sub

        Private Sub ApplyRanking(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            ApplyLayout(New GraphLayout(New RankingLayoutCalculator()))
        End Sub
        Private Sub LoadMDS(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            diagramControl.LoadDocument("Data/MDSLayout.xml")
        End Sub

        Private Sub ApplyMDS(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            ApplyLayout(New GraphLayout(New MDSLayoutCalculator()))
        End Sub

        Private Sub ApplyLayout(ByVal layout As GraphLayout)
            Try
                diagramControl.RelayoutDiagramItems(layout.RelayoutGraphNodesPosition(GraphOperations.GetDiagramGraph(diagramControl)))
                diagramControl.Items.OfType(Of IDiagramConnector)().ForEach(Sub(connector)
                    connector.Type = layout.GetDiagramConnectorType()
                    connector.UpdateRoute()
                End Sub)
                diagramControl.FitToDrawing()
            Catch e As Exception
                    DXMessageBox.Show(String.Format("Error message: '{0}'", e.Message), "Error has been occurred")
            End Try
        End Sub
    End Class
End Namespace