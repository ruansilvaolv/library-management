using LibraryManagement.Application.Services;
using LibraryManagement.Application.Interfaces;

namespace LibraryManagement.Infraestructure.UI
{
    public class LibraryConsoleUI
    {
        private readonly Library _library;
        private readonly IUIHelper _ui;

        public LibraryConsoleUI(Library library, IUIHelper ui)
        {
            _library = library;
            _ui = ui;
        }

        public void Run()
        {
            Console.WriteLine("Bem-vindo ao sistema de gerenciamento de Biblioteca!\n");

            int menuOpt;

            do
            {
                ShowMenu();
                menuOpt = _ui.ReadInt("Escolha: ");

                try
                {
                    switch (menuOpt)
                    {
                        case 0: Console.WriteLine("Encerrando sistema..."); break;
                        case 1: RegisterBook(); break;
                        case 2: RegisterUser(); break;
                        default: Console.WriteLine("Opção inválida! Tente novamente."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (menuOpt != 0);
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Digite a opção desejada:\n1 - Cadastrar Livro\n2 - Cadastrar Usuário\n0 - Sair");
        }

        public void RegisterBook()
        {
            string bookName = _ui.ReadString("Nome do livro: ");
            string author = _ui.ReadString("Nome do autor: ");
            string isbn = _ui.ReadString("ISBN: ");
            int publicationYear = _ui.ReadInt("Ano de publicação: ");

            _library.RegisterBook((bookName, author, isbn, publicationYear));
        }

        public void RegisterUser()
        {
            string userName = _ui.ReadString("Nome completo: ");
            string userEmail = _ui.ReadString("Digite o e-mail: ");
            string userPhone = _ui.ReadString("Digite o telefone: ");
            int userOpt = _ui.ReadInt("Digite opção desejada:\n1 - Usuário Comum\n2 - Estudante\n3 - Professor\n");

            _library.RegisterUser((userName, userEmail, userPhone, userOpt));
        }
    }
}
