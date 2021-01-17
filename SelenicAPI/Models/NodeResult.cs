namespace SelenicAPI.Models
{
    public class NodeResult
    {
        public Node Data { get; set; }

        public static NodeResult FromNode(Node node)
        {
            return new NodeResult { Data = node };
        }
    }
}
