using Autofac.Features.AttributeFilters;
using Autofac.Features.Indexed;
using Autofac.Features.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bnaya.Samples
{
    public class AlternateExecuter: IAlternateExecuter
    {
        private readonly IAlternate _special;
        private readonly IIndex<InstanceTypes, IAlternate> _mapper;
        private int _counter;
        private readonly int MAX;
        private readonly IEnumerable<Meta<IContext>> _contexts;
        private readonly IEnumerable<Meta<IContextPlus, ContextMeta>> _contextsPlus;
        private readonly IContextPlus _categoryD;

        public AlternateExecuter(
            [KeyFilter("Special")]IAlternate special,
            IIndex<InstanceTypes, IAlternate> mapper,
            [MetadataFilter("Category", "D")]IContextPlus categoryD,
            IEnumerable<Meta<IContext>> contexts,
            IEnumerable<Meta<IContextPlus, ContextMeta>> contextsPlus)
        {
            MAX = Enum.GetValues(typeof(InstanceTypes)).Length;
            _mapper = mapper;
            _special = special;

            _categoryD = categoryD;
            _contexts = contexts;
            _contextsPlus = contextsPlus;
        }

        public void Run()
        {
            IAlternate alternate;
            if (_counter == 0)
            {
                _special.Execute();
                Console.WriteLine("#D");
                _categoryD.Log(); 
                foreach (var context in _contexts)
                {
                    if (context.Metadata.ContainsKey("Category"))
                    {
                        if(context.Metadata.ContainsKey("Importance"))
                            Console.WriteLine($"Importance = {context.Metadata["Importance"]}");
                        string category = context.Metadata["Category"] as string;
                        Console.WriteLine($"Category = {category}");
                        context.Value.Log();
                    }
                }

                foreach (var context in _contextsPlus)
                {
                    string category = context.Metadata.Category;
                    Console.WriteLine($"Category = {category}");
                    context.Value.Log();
                }
            }
            _counter++;
            var key = (InstanceTypes)(_counter % MAX);
            alternate = _mapper[key];
            alternate.Execute();


        }
    }
}
