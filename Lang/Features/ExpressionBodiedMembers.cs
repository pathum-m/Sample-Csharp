namespace Lang.Features
{
    public class ExpressionBodiedMembers
    {
        private string _field;
        private string _field2;

        public ExpressionBodiedMembers(string field, string field2) => (_field, _field2) = (field, field2);

        public string Method() => string.Join("", new List<string> { _field, "*", "*" });

        public string Field => _field;

        public string Prop 
        { 
            get => _field; 
            set => _field = value; 
        }
    }
}
