namespace libreria
{
    public class Product
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }

        public double ExpectedEarnings { get; set; }

        public override string ToString()
        {
            var nl = System.Environment.NewLine;
            return $"Name: {this.Name}{nl}Description: {this.Description}{nl}Value: {this.Value}{nl}Expected Earnings: {this.ExpectedEarnings}";
        }
    }
}
