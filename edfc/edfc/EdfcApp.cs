using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inotech.Edfc
{
    public class EdfcApp
    {
        public string Version { get; set; }

        public void Initialize() {
        }


        public Catalogos.CatEstudiantesPresenter CreateCatEstudiantesPresenter(Catalogos.ICatEstudiantesView view) {
            return new Catalogos.CatEstudiantesPresenter(view);
        }

        public void End() {
        }

    }
}
