package com.tienda;

import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.TextArea;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.IOException;

public class ListarCelularesVentana {

    public void display() {
        Stage window = new Stage();
        window.setTitle("Listar Todos los Celulares");

        TextArea resultadoArea = new TextArea();
        resultadoArea.setEditable(false);

        try {
            String resultado = CelularService.listarCelulares();
            resultadoArea.setText(formatarCelulares(resultado));
        } catch (IOException e) {
            resultadoArea.setText("Error al obtener la lista de celulares: " + e.getMessage());
        }

        VBox layout = new VBox(10, resultadoArea);
        layout.setPadding(new Insets(20, 20, 20, 20));

        Scene scene = new Scene(layout, 400, 400);
        window.setScene(scene);
        window.showAndWait();
    }

    private String formatarCelulares(String jsonResultado) {
        StringBuilder sb = new StringBuilder();
        try {
            JSONArray jsonArray = new JSONArray(jsonResultado);
            for (int i = 0; i < jsonArray.length(); i++) {
                JSONObject celular = jsonArray.getJSONObject(i);
                sb.append("SKU: ").append(celular.getString("sku")).append("\n");
                sb.append("Nombre: ").append(celular.getString("nombre")).append("\n");
                sb.append("Descripción: ").append(celular.getString("descripcion")).append("\n");
                sb.append("Precio: ").append(celular.getDouble("precio")).append("\n");
                sb.append("Marca: ").append(celular.getString("marca")).append("\n");
                sb.append("------------------------\n");
            }
        } catch (Exception e) {
            return "Error al procesar los resultados: " + e.getMessage();
        }
        return sb.toString();
    }
}