namespace RhinoMocksUsage.Src
{
    class SampleContainer
    {
        private readonly ISample _sample;

        public SampleContainer(ISample sample)
        {
            _sample = sample;
        }

        public void MethodWithOutParameter(out int ret)
        {
            this._sample.MethodWithOutParameter(out ret);
        }
    }
}
