using System;
using System.Collections.Generic;
using System.Linq;

namespace UI.Models
{
    public class ModelRegistry : IFindModels
    {
        static IDictionary<Type, IList<object>> _models = new Dictionary<Type, IList<object>>();

        public IEnumerable<ModelType> FindAll<ModelType>()
        {
            return _models[typeof(ModelType)].Cast<ModelType>();
        }

        public void Register<ModelType>(ModelType model)
        {
            if(!_models.ContainsKey(typeof(ModelType)))
                _models.Add(typeof(ModelType), new List<object>());

            _models[typeof(ModelType)].Add(model);
        }

        public void UnRegister(object model)
        {
            _models[model.GetType()].Remove(model);
        }
    }
}