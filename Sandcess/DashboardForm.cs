using Northwoods.Go;
using Northwoods.Go.Models;
using Binding = Northwoods.Go.Models.Binding;
using Font = Northwoods.Go.Font;
using Panel = Northwoods.Go.Panel;


namespace Sandcess
{
	public partial class DashboardForm : Form
	{
		private const string DEFAULT_FONT_NAME = "Segoe UI";
		public class Model : GraphLinksModel<NodeData, string, object, object, string, string> { }
		public class NodeData : Model.NodeData { public string? Path { get; set; } }
		public class LinkData : Model.LinkData { }

		public DashboardForm()
		{
			InitializeComponent();
			
			Initialize();
		}

		private void Initialize()
		{
			Diagram diagram = diagramControlPathRelationship.Diagram;

			diagram.Scale = 0.2;
			diagram.AllowInsert = false;
			diagram.AllowDelete = false;
			diagram.AllowLink = false;
			diagram.AllowCopy = false;
			diagram.UndoManager.IsEnabled = true;
			diagram.Layout = new Northwoods.Go.Layouts.ForceDirectedLayout();

			diagram.NodeTemplate = GetNodeTemplate();
			diagram.LinkTemplate = GetLinkTemplate();
			diagram.Model = new Model{ NodeDataSource = GetNodeDataSource(), LinkDataSource = GetLinkDataSource() };
		}

		private Node GetNodeTemplate()
		{
			Dictionary<string, string> iconGeometry = new Dictionary<string, string>
			{
				{ "Permission", "M64 80c-8.8 0-16 7.2-16 16V416c0 8.8 7.2 16 16 16H384c8.8 0 16-7.2 16-16V96c0-8.8-7.2-16-16-16H64zM0 96C0 60.7 28.7 32 64 32H384c35.3 0 64 28.7 64 64V416c0 35.3-28.7 64-64 64H64c-35.3 0-64-28.7-64-64V96zM337 209L209 337c-9.4 9.4-24.6 9.4-33.9 0l-64-64c-9.4-9.4-9.4-24.6 0-33.9s24.6-9.4 33.9 0l47 47L303 175c9.4-9.4 24.6-9.4 33.9 0s9.4 24.6 0 33.9z" },
				{ "Container", "M64 464H288c8.8 0 16-7.2 16-16V384h48v64c0 35.3-28.7 64-64 64H64c-35.3 0-64-28.7-64-64V224c0-35.3 28.7-64 64-64h64v48H64c-8.8 0-16 7.2-16 16V448c0 8.8 7.2 16 16 16zM224 304H448c8.8 0 16-7.2 16-16V64c0-8.8-7.2-16-16-16H224c-8.8 0-16 7.2-16 16V288c0 8.8 7.2 16 16 16zm-64-16V64c0-35.3 28.7-64 64-64H448c35.3 0 64 28.7 64 64V288c0 35.3-28.7 64-64 64H224c-35.3 0-64-28.7-64-64z" },
				{ "DigitalSignature", "M192 128c0-17.7 14.3-32 32-32s32 14.3 32 32v7.8c0 27.7-2.4 55.3-7.1 82.5l-84.4 25.3c-40.6 12.2-68.4 49.6-68.4 92v71.9c0 40 32.5 72.5 72.5 72.5c26 0 50-13.9 62.9-36.5l13.9-24.3c26.8-47 46.5-97.7 58.4-150.5l94.4-28.3-12.5 37.5c-3.3 9.8-1.6 20.5 4.4 28.8s15.7 13.3 26 13.3H544c17.7 0 32-14.3 32-32s-14.3-32-32-32H460.4l18-53.9c3.8-11.3 .9-23.8-7.4-32.4s-20.7-11.8-32.2-8.4L316.4 198.1c2.4-20.7 3.6-41.4 3.6-62.3V128c0-53-43-96-96-96s-96 43-96 96v32c0 17.7 14.3 32 32 32s32-14.3 32-32V128zm-9.2 177l49-14.7c-10.4 33.8-24.5 66.4-42.1 97.2l-13.9 24.3c-1.5 2.6-4.3 4.3-7.4 4.3c-4.7 0-8.5-3.8-8.5-8.5V335.6c0-14.1 9.3-26.6 22.8-30.7zM24 368c-13.3 0-24 10.7-24 24s10.7 24 24 24H64.3c-.2-2.8-.3-5.6-.3-8.5V368H24zm592 48c13.3 0 24-10.7 24-24s-10.7-24-24-24H305.9c-6.7 16.3-14.2 32.3-22.3 48H616z" }
			};


			string GetNodeName(object obj)
			{
				string path = (string)obj;
				string ret = FileUtils.GetName(path);

				if (FileUtils.IsDirectory(path))
					ret += "\\";
				return ret;
			}

			string GetPermission(object obj)
			{
				string ret = "";
				string path = (string)obj;
				uint permission = AccessController.GetPermission(path);
				List<string> permissionNameList = new List<string>
				{
					"Read File",
					"Write File",
					"Move File",
					"Create Process", 
					"Send Packet",
					"Receive Packet"
				};

				for (int idx = 0; idx < permissionNameList.Count; idx++)
				{
					if (((permission >> (idx + 2)) & 1) == 1)
						ret += permissionNameList[idx] + "\n";
				}
				ret = ret.Trim();
				return ((ret != "" && FileUtils.IsExists(path)) ? ret : "-");
			}

			string GetContainer(object obj)
			{
				string ret = "";
				string path = (string)obj;

				foreach (string container in ContainerController.GetContainerListByTargetPath(path))
					ret += container + "(T)\n";
				foreach (string container in ContainerController.GetContainerListByAccessiblePath(path))
					ret += container + "(A)\n";

				ret = ret.Trim();
				return (ret != "" && FileUtils.IsExists(path) ? ret : "-");
			}

			string GetDigitalSignature(object obj)
			{
				string path = (string)obj;
				string digitalSignature = FileUtils.GetDigitalSignature(path);
				return (digitalSignature != "" ? digitalSignature : "-");
			}


			Panel nodeInfo = new Panel(PanelType.Vertical) { Stretch = Stretch.Fill }.Add(
				new Shape
				{
					Height = 0,
					Margin = 5,
					Stroke = "#d5d8dc",
					StrokeWidth = 1,
					Stretch = Stretch.Fill,
				},
				new Panel(PanelType.Horizontal) { Alignment = Spot.Left }.Add(
					new Shape
					{
						Margin = 3,
						StrokeWidth = 0,
						Width = 15,
						Height = 15,
						Fill = "#2ecc71",
						Geometry = Geometry.Parse(iconGeometry["Permission"], true)
					},
					new TextBlock
					{
						Margin = 4,
						Stroke = "#1b2631",
						Font = new Font(DEFAULT_FONT_NAME, 14, FontWeight.Bold)
					}.Bind(
						new Binding("Text", "Path", GetPermission)
					)
				),
				new Panel(PanelType.Horizontal) { Alignment = Spot.Left }.Add(
					new Shape
					{
						Margin = 3,
						StrokeWidth = 0,
						Width = 15,
						Height = 15,
						Fill = "#5dade2",
						Geometry = Geometry.Parse(iconGeometry["Container"], true)
					},
					new TextBlock
					{
						Margin = 4,
						Stroke = "#1b2631",
						Font = new Font(DEFAULT_FONT_NAME, 14, FontWeight.Bold)
					}.Bind(
						new Binding("Text", "Path", GetContainer)
					)
				),
			new Panel(PanelType.Horizontal) { Alignment = Spot.Left }.Add(
					new Shape
					{
						Margin = 3,
						StrokeWidth = 0,
						Width = 15,
						Height = 15,
						Fill = "#dc7633",
						Geometry = Geometry.Parse(iconGeometry["DigitalSignature"], true)
					},
					new TextBlock
					{
						Margin = 4,
						Stroke = "#1b2631",
						Font = new Font(DEFAULT_FONT_NAME, 14, FontWeight.Bold)
					}.Bind(
						new Binding("Text", "Path", GetDigitalSignature)
					)
				),
				new Shape
				{
					Height = 0,
					Margin = 5,
					Stroke = "#d5d8dc",
					StrokeWidth = 1,
					Stretch = Stretch.Fill,
				},
				new Panel(PanelType.Horizontal) { Alignment = Spot.Center }.Add(
					Builder.Make<Panel>("Button").Set(new
					{
						Click = new Action<InputEvent, GraphObject>((e, obj) =>
						{
							string key = obj.Part.Key.ToString();
							List<NodeData> nodeDataList = (List<NodeData>)obj.Part.Diagram.Model.NodeDataSource;
							NodeData nodeData = nodeDataList[nodeDataList.FindIndex(target => (target.Key == key))];
							FileUtils.OpenWindowsExplorer(nodeData.Path);
						})
					}).Add(
						new TextBlock
						{
							Margin = 1,
							Text = "Open",
							Stroke = "#273746",
							Font = new Font(DEFAULT_FONT_NAME, 12, FontWeight.Bold)
						}
					)
				)
			);

			return new Node(PanelType.Auto)
			{
				SelectionAdorned = false,
				LayoutConditions = (LayoutConditions.Standard & (~LayoutConditions.NodeSized)),
				ToSpot = Spot.AllSides,
				FromSpot = Spot.AllSides
			}.Add(
				new Shape()
				{
					Figure = "RoundedRectangle",
					Fill = "white",
					Stroke = "#eeeeee",
					StrokeWidth = 4
				},
				new Panel(PanelType.Table)
				{
					Margin = 5,
					Stretch = Stretch.Fill
				}.Add(
					new TextBlock
					{
						Row = 0,
						Alignment = Spot.Center,
						Margin = new Margin(0, 22, 0, 0),
						Font = new Font(DEFAULT_FONT_NAME, 16, FontWeight.Bold)
					}.Bind(
						new Binding("Text", "Path", GetNodeName)
					),
					new Panel(PanelType.Vertical)
					{
						Alignment = Spot.TopRight
                    }.Add(
						Builder.Make<Panel>("PanelExpanderButton", "NodeInfo")
					),
					new Panel(PanelType.Vertical)
					{
						Name = "NodeInfo",
						Visible = false,
						Row = 1,
						Alignment = Spot.Left,
						Stretch = Stretch.Fill
					}.Add(
						nodeInfo
					)
				)
			);
		}

		private Link GetLinkTemplate()
		{
			return new Link
			{
				SelectionAdorned = false,
				Corner = 10,
				Routing = LinkRouting.AvoidsNodes,
				Curve = LinkCurve.JumpOver
			}.Add(
				new Shape { Stroke = "#212f3d", StrokeWidth = 2.5 },
				new Shape { ToArrow = "OpenTriangle", Fill = null, StrokeWidth = 2.5 }
			);
		}

		private List<NodeData> GetNodeDataSource()
		{
			List<NodeData> ret = new List<NodeData>();
			HashSet<string> pathHashSet = new HashSet<string>();

			void AddNodeData(string path)
			{
				if (!pathHashSet.Contains(path))
				{
					ret.Add(new NodeData { Key = path, Path = path });
					pathHashSet.Add(path);
				}
			}

			foreach (string path in AccessController.GetPathList())
				AddNodeData(path);

			foreach (string container in ContainerController.GetContainerList())
			{
				List<string> targetPathList = ContainerController.GetTargetPathList(container);
				List<string> accessiblePathList = ContainerController.GetAccessiblePathList(container);

				foreach (string path in targetPathList)
					AddNodeData(path);
				foreach (string path in accessiblePathList)
					AddNodeData(path);
			}
			return ret;
		}

		private List<LinkData> GetLinkDataSource()
		{
			List<LinkData> ret = new List<LinkData>();
            HashSet<KeyValuePair<string, string>> pathPairHashSet = new HashSet<KeyValuePair<string, string>>();

            void AddLinkData(string targetPath, string accessiblePath)
			{
				KeyValuePair<string, string> pathPair = new KeyValuePair<string, string>(targetPath, accessiblePath);

				if (!pathPairHashSet.Contains(pathPair))
				{
					ret.Add(new LinkData { To = accessiblePath, From = targetPath });
					pathPairHashSet.Add(pathPair);
				}
			}

			foreach (string container in ContainerController.GetContainerList())
			{
				List<string> targetPathList = ContainerController.GetTargetPathList(container);
				List<string> accessiblePathList = ContainerController.GetAccessiblePathList(container);

				foreach (string targetPath in targetPathList)
				{
					foreach (string accessiblePath in accessiblePathList)
						AddLinkData(targetPath, accessiblePath);
                }
			}
			return ret;
		}
	}
}
