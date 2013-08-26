using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inotech.Edfc.Catalogos
{
    public class CatEstudiantesPresenter
    {
        private ICatEstudiantesView _view;

        public CatEstudiantesPresenter(ICatEstudiantesView view) {
            _view = view;
        }

        public void NewCommand() {
            _view.SetEditionMode(EEditionMode.Alta);
        }

        public void SaveCommand() {
            _view.SetEditionMode(EEditionMode.Navegacion);
        }

        public void CloseCommand() {

        }

    }
}
