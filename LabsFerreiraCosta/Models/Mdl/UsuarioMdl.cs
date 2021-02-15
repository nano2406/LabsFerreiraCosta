using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace LabsFerreiraCosta.Models {

/* File History
 * --------------------------------------------------------------------
 * Created by : Luciano Filho
 * Date       : 13/02/2021
 * Purpose    : Criação da Mdl do Usuário
 * --------------------------------------------------------------------
 */

    public class UsuarioMdl {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do Usuário")]
        public String Nome { get; set; }
       
        [Required(ErrorMessage = "Informe o Login do Usuário")]
        public String Login { get; set; }
       
        [Required(ErrorMessage = "Informe a Senha do Usuário")]
        public String Senha { get; set; }
       
        [Required(ErrorMessage = "Informe o Email do Usuário")]
        public String Email { get; set; }
        
        [Required(ErrorMessage = "Informe o Fone do Usuário")]  
        public String Fone { get; set; }
        
        [Required(ErrorMessage = "Informe o CPF do Usuário")]
        public String Cpf { get; set; }
        
        [Required(ErrorMessage = "Informe a Data de Nascimento do Usuário")]  
        public DateTime DataNascimento { get; set; }
       
        [Required(ErrorMessage = "Informe o nome da mãe do Usuário")]
        public String NomeMae { get; set; }
        
        [Required(ErrorMessage = "Informe o Status do Usuário")]
        public String Status { get; set; }

        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}