using Northwoods.Go;
using Northwoods.Go.Models;
using Binding = Northwoods.Go.Models.Binding;
using Font = Northwoods.Go.Font;
using Panel = Northwoods.Go.Panel;

namespace Sandcess
{
	internal class DiagramController
	{
		private const string DEFAULT_FONT_NAME = "Microsoft YaHei";
		public class PathRelationshipModel : GraphLinksModel<PathRelationshipNodeData, string, object, object, string, string> { }
		public class PathRelationshipNodeData : PathRelationshipModel.NodeData { public List<PathRelationshipFieldData>? Items { get; set; } }
		public class PathRelationshipLinkData : PathRelationshipModel.LinkData { }

		public class PathRelationshipFieldData
		{
			public string? Type { get; set; }
			public string? Data { get; set; }
		}

		public static Node GetPathRelationshipNodeTemplate()
		{
			Panel panelExpanderButton = Builder.Make<Panel>("PanelExpanderButton", "FieldItemList");
			panelExpanderButton.Alignment = Spot.TopRight;

			Panel itemTemplate = new Panel(PanelType.Horizontal).Add(
				new TextBlock {
					Stroke = "#1b2631",
					Font = new Font(DEFAULT_FONT_NAME, 14, FontWeight.Bold)
				}.Bind(
					new Binding("Text", "Data")
				)
			);

			return new Node(PanelType.Auto) {
				SelectionAdorned = false,
				LayoutConditions = (LayoutConditions.Standard & (~LayoutConditions.NodeSized)),
				ToSpot = Spot.AllSides,
				FromSpot = Spot.AllSides
            }.Add(
				new Shape() {
					Figure = "RoundedRectangle",
					Fill = "white",
					Stroke = "#eeeeee",
					StrokeWidth = 4
				},
				new Panel(PanelType.Table) {
					Margin = 8,
					Stretch = Stretch.Fill
				}.Add(
					new TextBlock {
						Row = 0,
						Alignment = Spot.Center,
						Margin = new Margin(0, 22, 0, 0),
						Font = new Font(DEFAULT_FONT_NAME, 16, FontWeight.Bold)
					}.Bind(
						new Binding("Text", "Key")
					),
					panelExpanderButton,
					new Panel(PanelType.Vertical) {
						Name = "FieldItemList",
						Row = 1,
						Padding = 3,
						DefaultAlignment = Spot.Left,
						Stretch = Stretch.Horizontal,
						ItemTemplate = itemTemplate
                    }.Bind(
						new Binding("ItemList", "Items")
					)
				)
			);
		}

		public static Link GetPathRelationshipLinkTemplate()
		{
			return new Link {
				Reshapable = false,
				Corner = 10,
				Routing = LinkRouting.AvoidsNodes,
				Curve = LinkCurve.JumpOver
			}.Add(
				new Shape { Stroke = "#212f3d", StrokeWidth = 2.5 }
			);
		}

		public static PathRelationshipModel GetPathRelationshipModel()
		{
			List<PathRelationshipNodeData> nodeDataSource = new List<PathRelationshipNodeData>();
			nodeDataSource.Add(
				new PathRelationshipNodeData {
					Key = "key1",
					Items = new List<PathRelationshipFieldData> {
						new PathRelationshipFieldData {
							Type = "type-1", Data = "test-data"
						}
					}
				}
			);
			nodeDataSource.Add(
				new PathRelationshipNodeData {
					Key = "key2",
					Items = new List<PathRelationshipFieldData> {
						new PathRelationshipFieldData {
							Type = "type-1", Data = "test-data"
						}
					}
				}
			);


			List<PathRelationshipLinkData> linkDataSource = new List<PathRelationshipLinkData>();
			linkDataSource.Add(new PathRelationshipLinkData { To = "key1", From = "key2" });


			return new PathRelationshipModel {
				NodeDataSource = nodeDataSource,
				LinkDataSource = linkDataSource
			};
		}
	}
}
