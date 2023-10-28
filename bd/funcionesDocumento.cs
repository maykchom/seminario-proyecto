// Funciones para cifrar contraseñas
private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
{
    byte[] encryptedBytes = null;
    var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

    using (MemoryStream ms = new MemoryStream())
    {
        using (RijndaelManaged AES = new RijndaelManaged())
        {
            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CBC;

            using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                cs.Close();
            }

            encryptedBytes = ms.ToArray();
        }
    }

    return encryptedBytes;
}

public static string cifrar(string texto)
{
    if (texto == null)
    {
        return null;
    }
    // Obtener los bytes de la cadena
    var bytesToBeEncrypted = Encoding.UTF8.GetBytes(texto);
    var passwordBytes = Encoding.UTF8.GetBytes(password);

    // Hash la contraseña con SHA256
    passwordBytes = SHA512.Create().ComputeHash(passwordBytes);

    var bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);

    return Convert.ToBase64String(bytesEncrypted);
}



//Funciones para descifrar  contraseñas
private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
{
    byte[] decryptedBytes = null;
    var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

    using (MemoryStream ms = new MemoryStream())
    {
        using (RijndaelManaged AES = new RijndaelManaged())
        {
            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Mode = CipherMode.CBC;

            using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                cs.Close();
            }

            decryptedBytes = ms.ToArray();
        }
    }

    return decryptedBytes;
}

public static string descifrar(string textoCifrado)
{
    if (textoCifrado == null)
    {
        return null;
    }
    // Obtener los bytes de la cadena
    var bytesToBeDecrypted = Convert.FromBase64String(textoCifrado);
    var passwordBytes = Encoding.UTF8.GetBytes(password);

    passwordBytes = SHA512.Create().ComputeHash(passwordBytes);

    var bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);

    return Encoding.UTF8.GetString(bytesDecrypted);
}



//Generar afiches
private void btnImprimir_Click(object sender, EventArgs e)
{
    DataTable dtDatos;
    dtDatos = capaNegocias.convocatorias.cargarDatosAfiche(idConvo);
    afiche.datos encabezado = new afiche.datos();
    encabezado.ID_CONVOCATORIA = dtDatos.Rows[0][0].ToString();
    encabezado.INICIO = dtDatos.Rows[0][1].ToString();
    encabezado.FIN = dtDatos.Rows[0][2].ToString();
    encabezado.OBSERVACIONES = dtDatos.Rows[0][3].ToString();
    encabezado.ID_PUESTO = dtDatos.Rows[0][4].ToString();
    encabezado.TITULO = dtDatos.Rows[0][5].ToString();
    encabezado.DESCRIPCION = dtDatos.Rows[0][6].ToString();
    encabezado.PERFIL = dtDatos.Rows[0][7].ToString();

    afiche.aficheFormulario aficheAbrir = new afiche.aficheFormulario();
    aficheAbrir.de.Add(encabezado);
    aficheAbrir.ShowDialog();
    dtDatos.Clear();
}


//Iniciar sesion
 private void iniciarSesion()
{
    if (!capaNegocias.metodosComunes.verificarConexion())
    {
        MessageBox.Show("No hay conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    datosSesion.Clear();
    datosSesion = sesion.iniciarSesion(tbUser.Text, cifrar(tbPass.Text));
    int value = datosSesion.Rows.Count;

    if (value == 1)
    {

        if (Convert.ToInt32(datosSesion.Rows[0][10]) == 1)
        {
            sesion.id_usuario = datosSesion.Rows[0][0].ToString();
            sesion.id_rol = (int)datosSesion.Rows[0][9];            
            if (Convert.ToInt32(datosSesion.Rows[0][9]) == 1)
            {
                this.Hide();
                menuAdmin abrir = new menuAdmin();
                abrir.Show();
            }
            else
            {
                this.Hide();
                menuSecre abrir = new menuSecre();
                abrir.Show();
            }            
        }
        else
        {
            MessageBox.Show("El usuario " + datosSesion.Rows[0][0].ToString() + " ha sido dado de baja", "No disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    else
    {
        MessageBox.Show("Las credenciales son erróneas", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}


//Guardar resultados entrevista
public void guardarResultados()
{
    int idPostulacion = capaNegocias.entrevistaEjecucion.idPostulacionEntrevista;
    foreach (DataRow fila in respuestasSeleccionadas.Rows)
    {
        if (!capaNegocias.entrevistaEjecucion.guardarResultados(idPostulacion, Convert.ToInt32(fila[0]), Convert.ToInt32(fila[1])))
        {
            //MessageBox.Show("Guardado: idPregunta: " + fila[0].ToString() + " idRespuesta: " + fila[1].ToString());                    
            MessageBox.Show("Resultado no guardado, intente de nuevo", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            regresarVentanaAnterior();
            return;
        }
    }

    if (!capaNegocias.entrevistaEjecucion.editarEstadoPostulacion(idPostulacion))
    {
        //MessageBox.Show("Guardado: idPregunta: " + fila[0].ToString() + " idRespuesta: " + fila[1].ToString());                    
        MessageBox.Show("Hubo un error en la postulación, intente de nuevo", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
        regresarVentanaAnterior();
        return;
    }
    else
    {
        MessageBox.Show("La entrevista se completó exitosamente", "Entrevista finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        regresarVentanaAnterior();
    }

}