namespace inlock_codeFirst.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Gera uma hash a partir de uma senha 
        /// </summary>
        /// <param name="senha">Senha que recebera a hash</param>
        /// <returns>senha criptografada</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a hash da senha informada e igual a hash salva no banco
        /// </summary>
        /// <param name="senhaForm">Senha informada pelo usuario</param>
        /// <param name="senhaBanco">Senha cadastrada</param>
        /// <returns>true or false</returns>

        public static bool CompararHash(string senhaForm, string senhaBanco) 
        { 
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
