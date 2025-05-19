public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public Feature[] features { get; set; } //According to external source docs, the results brings a list of features
}

public class Feature
{
    public Properties properties { get; set; } //According to the docs, each feature brings a list of properties
}

public class Properties
{
    public string place { get; set; } //string with eathquake's place
    public decimal mag { get; set; } //earthquake's magnitude
}