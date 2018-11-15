<!-- default file list -->
*Files to look at*:

* [LayoutExampleWindow.xaml](./CS/DXDiagram.CustomLayoutAlgorithms/LayoutExampleWindow.xaml) (VB: [LayoutExampleWindow.xaml.vb](./VB/DXDiagram.CustomLayoutAlgorithms/LayoutExampleWindow.xaml.vb))
* [LayoutExampleWindow.xaml.cs](./CS/DXDiagram.CustomLayoutAlgorithms/LayoutExampleWindow.xaml.cs) (VB: [LayoutExampleWindow.xaml.vb](./VB/DXDiagram.CustomLayoutAlgorithms/LayoutExampleWindow.xaml.vb))
* [MainWindow.xaml](./CS/DXDiagram.CustomLayoutAlgorithms/MainWindow.xaml) (VB: [MainWindow.xaml.vb](./VB/DXDiagram.CustomLayoutAlgorithms/MainWindow.xaml.vb))
* [MainWindow.xaml.cs](./CS/DXDiagram.CustomLayoutAlgorithms/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DXDiagram.CustomLayoutAlgorithms/MainWindow.xaml.vb))
* [Converter.cs](./CS/MsaglHelpers/Converter.cs) (VB: [Converter.vb](./VB/MsaglHelpers/Converter.vb))
* [GraphLayout.cs](./CS/MsaglHelpers/Layout/GraphLayout.cs) (VB: [GraphLayout.vb](./VB/MsaglHelpers/Layout/GraphLayout.vb))
* [PhyloTreeLayout.cs](./CS/MsaglHelpers/Layout/PhyloTreeLayout.cs) (VB: [PhyloTreeLayout.vb](./VB/MsaglHelpers/Layout/PhyloTreeLayout.vb))
* [DisconnectedGraphsLayoutCaculator.cs](./CS/MsaglHelpers/LayoutCalculators/DisconnectedGraphsLayoutCaculator.cs) (VB: [DisconnectedGraphsLayoutCaculator.vb](./VB/MsaglHelpers/LayoutCalculators/DisconnectedGraphsLayoutCaculator.vb))
* [ILayoutCalculator.cs](./CS/MsaglHelpers/LayoutCalculators/ILayoutCalculator.cs) (VB: [ILayoutCalculator.vb](./VB/MsaglHelpers/LayoutCalculators/ILayoutCalculator.vb))
* [MDSLayoutCalculator.cs](./CS/MsaglHelpers/LayoutCalculators/MDSLayoutCalculator.cs) (VB: [MDSLayoutCalculator.vb](./VB/MsaglHelpers/LayoutCalculators/MDSLayoutCalculator.vb))
* [PhyloTreeLayoutCalculator.cs](./CS/MsaglHelpers/LayoutCalculators/PhyloTreeLayoutCalculator.cs) (VB: [PhyloTreeLayoutCalculator.vb](./VB/MsaglHelpers/LayoutCalculators/PhyloTreeLayoutCalculator.vb))
* [RankingLayoutCalculator.cs](./CS/MsaglHelpers/LayoutCalculators/RankingLayoutCalculator.cs) (VB: [RankingLayoutCalculator.vb](./VB/MsaglHelpers/LayoutCalculators/RankingLayoutCalculator.vb))
* [SugiyamaLayoutCalculator.cs](./CS/MsaglHelpers/LayoutCalculators/SugiyamaLayoutCalculator.cs) (VB: [SugiyamaLayoutCalculator.vb](./VB/MsaglHelpers/LayoutCalculators/SugiyamaLayoutCalculator.vb))
* [MsaglGeometryGraphHelpers.cs](./CS/MsaglHelpers/MsaglGeometryGraphHelpers.cs) (VB: [MsaglGeometryGraphHelpers.vb](./VB/MsaglHelpers/MsaglGeometryGraphHelpers.vb))
* [RoutingHelper.cs](./CS/MsaglHelpers/RoutingHelper.cs) (VB: [RoutingHelper.vb](./VB/MsaglHelpers/RoutingHelper.vb))
<!-- default file list end -->
# How to use custom graph layout algorithms to arrange shapes in DiagramControl


DiagramControl provides two methods that make it easier to use external graph layout algorithms to arrange diagram shapes. The <strong><em>GraphOperations.GetDiagramGraph</em></strong> method reads the diagram currently loaded into DiagramControl and returns the <strong><em>Graph</em></strong> object that contains collections of edges and nodes represented by diagram items. You can use this information to calculate positions for diagram shapes. Then, for every shape, create the <strong><em>PositionInfo</em> </strong>object containing the shape reference and its position. To apply the layout to the loaded diagram, call the <em><strong>DiagramControl.RelayoutDiagramItems</strong></em> method that accepts the collection of PositionInfo objects.<br><br>This example demonstrates how the GetDiagramGraph and RelayoutDiagramItems methods can be used to connect the <a href="https://github.com/Microsoft/automatic-graph-layout">Microsoft Automatic Graph Layout (MSAGL)</a> library to DiagramControl.

<br/>


