using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using Inotech.Edfc.Catalogos;

namespace Inotech.Edfc.Test.EndToEnd
{
    [TestFixture]
    public class EdfcTest
    {
        /// <summary>
        /// Este es el primer test EndToEnd de esta aplicacion que nos ayuda a identificar
        /// los componentes principales de la aplicación. 
        /// Para poder implementar EndToEnd Testing estamos usando el patrón de diseño MVP-VM 
        /// en su modalidad pasiva.
        /// 
        /// Aqui debemos probar todos los componentes reales, el único sustituto que utilizaremos 
        /// es la vista (view)
        /// </summary>
        [Test]
        public void RegistraUnEstudiante() {
            Inotech.Edfc.EdfcApp myApp = new Inotech.Edfc.EdfcApp();
            Dictionary<string, string> fieldsIn = new Dictionary<string, string>();
            Dictionary<string, string> fields = new Dictionary<string, string>();
            Dictionary<string, string> fieldsOut = new Dictionary<string, string>();

            myApp.Initialize();
            ICatEstudiantesView view = Substitute.For<ICatEstudiantesView, ICatEstudiantesTestableView>();
            ICatEstudiantesTestableView testableView = (ICatEstudiantesTestableView)view;

            //Pide a la aplicación que cree un nuevo presenter del Catalogo de estudiantes y 
            // lo liga a la vista que acabamos de crear
            CatEstudiantesPresenter presenter = myApp.CreateCatEstudiantesPresenter(view);

            //Vamos a establecer el modo de la vista a ALTA asi que preparamos la vista falsa para responder
            // a esta petición
            EEditionMode currentEditionMode=0;
            view.SetEditionMode(Arg.Do<EEditionMode>(x => currentEditionMode = x));
            testableView.EditionMode.Returns(x => currentEditionMode);

            // Inicializa la vista y el presentador
            view.Initialize(presenter);

            testableView.When(x => x.ClickOnNewButton()).Do(x => presenter.NewCommand());
            testableView.When(x => x.ClickOnSaveButton()).Do(x => presenter.SaveCommand());
            testableView.When(x => x.ClickOnCloseButton()).Do(x => presenter.CloseCommand());

            //Simula el click sobre el boton "Nuevo"
            testableView.ClickOnNewButton();

            //La vista debe estar en modo de alta
            Assert.AreEqual(Catalogos.EEditionMode.Alta, currentEditionMode);
            Assert.AreEqual(Catalogos.EEditionMode.Alta, testableView.EditionMode ); 

            //Despliega datos de cliente simulando que el usuario ha capturado datos
            view.DisplayItemFields(Arg.Do<Dictionary<string,string>>(x => fields = x));
            testableView.ItemFields.Returns(x => fields);

            fieldsIn.Add("Id", "0");
            fieldsIn.Add("Apellido", "Apellido");
            fieldsIn.Add("Nombre", "Nombre");
            fieldsIn.Add("Nacimiento", new DateTime(1969,08,15).ToString("yyyy-MM-dd"));
            view.DisplayItemFields(fieldsIn);

            fieldsOut = testableView.ItemFields;
            Assert.IsTrue(fieldsIn.ContainsKey("Id"));
            Assert.IsTrue(fieldsIn.ContainsKey("Apellido"));
            Assert.IsTrue(fieldsIn.ContainsKey("Nombre"));
            Assert.IsTrue(fieldsIn.ContainsKey("Nacimiento"));

            Assert.AreEqual(fieldsIn["Id"],fieldsOut["Id"]);
            Assert.AreEqual(fieldsIn["Apellido"], fieldsOut["Apellido"]);
            Assert.AreEqual(fieldsIn["Nombre"], fieldsOut["Nombre"]);
            Assert.AreEqual(fieldsIn["Nacimiento"], fieldsOut["Nacimiento"]);

            //No debe haber errores de validación
            view.Validate();
            Assert.AreEqual(0, testableView.ValidationErrors.Count);

            //Simulamos el click sobre el botón grabar
            testableView.ClickOnSaveButton();

            //Cerramos el modulo de captura de estudiantes
            testableView.ClickOnCloseButton();

            //Cerramos la aplicacion
            myApp.End();

        }
        
    }
}
