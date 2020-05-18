using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecours.Desktop.ViewModel
{

    public interface IApplicationCommands {
        CompositeCommand ExitCommand { get; }

        CompositeCommand LoadCommand { get; }

        CompositeCommand LoadAccountModule { get; }
    }
    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand ExitCommand { get; } = new CompositeCommand();

        public CompositeCommand LoadCommand { get; } = new CompositeCommand();

        public CompositeCommand LoadAccountModule { get; } = new CompositeCommand();

    }
}
