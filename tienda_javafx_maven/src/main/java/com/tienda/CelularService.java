
package com.tienda;

import java.io.*;
import java.net.*;
import java.nio.charset.StandardCharsets;

public class CelularService {

    public static String listarCelulares() throws IOException {
        URL url = new URL("http://localhost:8000/celulares");
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setRequestMethod("GET");
        return readResponse(con);
    }
    //  Método en BuscarCelularVentana.java para buscar por sku

    public static String get_celular_by_sku(String sku) throws IOException {
        URL url = new URL("http://localhost:8000/celulares/" + sku);
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setRequestMethod("GET");
        return readResponse(con);
    }
      //Método en CrearCelularVentana
    public static String crearCelular(String json) throws IOException {
        URL url = new URL("http://localhost:8000/celulares/create");
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setRequestMethod("POST");
        con.setDoOutput(true);
        con.setRequestProperty("Content-Type", "application/json");

        try (OutputStream os = con.getOutputStream()) {
            byte[] input = json.getBytes(StandardCharsets.UTF_8);
            os.write(input, 0, input.length);
        }
        return readResponse(con);
    }
    //Método en EliminarCelularVentana
    public static String eliminarCelular(String sku) throws IOException {
        URL url = new URL("http://localhost:8000/celulares/" + sku + "/delete");
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setRequestMethod("DELETE");

        int status = con.getResponseCode();
        if (status == HttpURLConnection.HTTP_OK) {
            return "Celular eliminado con éxito.";
        } else {
            return "Error al eliminar el celular. Código de estado: " + status;
        }
    }
    //Método en ActualizarCelularVentana
    public static String actualizarCelular(String sku, String json) throws IOException {
        URL url = new URL("http://localhost:8000/celulares/" + sku + "/update");
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setRequestMethod("PUT");
        con.setDoOutput(true);
        con.setRequestProperty("Content-Type", "application/json");

        try (OutputStream os = con.getOutputStream()) {
            byte[] input = json.getBytes(StandardCharsets.UTF_8);
            os.write(input, 0, input.length);
        }

        int status = con.getResponseCode();
        if (status == HttpURLConnection.HTTP_OK) {
            return "Celular actualizado con éxito.";
        } else {
            return "Error al actualizar el celular. Código de estado: " + status;
        }
    }

    /*
    public static String agregarCargador(String sku, String json) throws IOException {
        URL url = new URL("http://localhost:8000/celulares/" + sku + "/cargadores/create");
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setRequestMethod("POST");
        con.setDoOutput(true);
        con.setRequestProperty("Content-Type", "application/json");

        try (OutputStream os = con.getOutputStream()) {
            byte[] input = json.getBytes(StandardCharsets.UTF_8);
            os.write(input, 0, input.length);
        }
        return readResponse(con);
    }

    public static String listarCargadores(String sku) throws IOException {
        URL url = new URL("http://localhost:8000/celulares/" + sku + "/cargadores");
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setRequestMethod("GET");
        return readResponse(con);
    }*/
    //Filtros en ListarCelularesFiltradoVentana
     public static String listarCelularesPorMarca(String marca) throws IOException {
        URL url = new URL("http://localhost:8000/celulares/buscar-por-marca?marca=" + URLEncoder.encode(marca, StandardCharsets.UTF_8));
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setRequestMethod("GET");
        return readResponse(con);
    }

    public static String listarCelularesPorRangoPrecio(double precioDesde, double precioHasta) throws IOException {
        URL url = new URL("http://localhost:8000/celulares/buscar-por-precio?precio_desde=" + precioDesde + "&precio_hasta=" + precioHasta);
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setRequestMethod("GET");
        return readResponse(con);
    }

    private static String readResponse(HttpURLConnection con) throws IOException {
        int status = con.getResponseCode();
        InputStream stream = (status >= 400) ? con.getErrorStream() : con.getInputStream();

        BufferedReader reader = new BufferedReader(new InputStreamReader(stream));
        StringBuilder response = new StringBuilder();
        String line;
        while ((line = reader.readLine()) != null) {
            response.append(line);
        }
        reader.close();

        if (status >= 400) {
            throw new IOException("Error " + status + ": " + response.toString());
        }
        return response.toString();
    }
    
    
}
