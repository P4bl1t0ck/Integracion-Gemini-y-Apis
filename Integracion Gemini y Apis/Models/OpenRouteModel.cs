namespace Integracion_Gemini_y_Apis.Models
{
    public class RouteResponse
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
        public List<double> bbox { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public List<double> bbox { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Properties
    {
        public List<Segment> segments { get; set; }
        public Summary summary { get; set; }
    }

    public class Segment
    {
        public double distance { get; set; }
        public double duration { get; set; }
        public List<Step> steps { get; set; }
    }

    public class Step
    {
        public string instruction { get; set; }
        public double distance { get; set; }
        public double duration { get; set; }
        public int type { get; set; }
        public int way_points_start { get; set; }
        public int way_points_end { get; set; }
    }

    public class Summary
    {
        public double distance { get; set; }
        public double duration { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<List<double>> coordinates { get; set; }
    }
}
