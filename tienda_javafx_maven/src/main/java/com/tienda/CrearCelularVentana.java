package com.tienda;

import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import org.json.JSONObject;

import java.io.IOException;

public class CrearCelularVentana {

    public void display() {
        Stage window = new Stage();
        window.setTitle("Crear Celular");

        TextField skuField = new TextField();
        TextField nombreField = new TextField();
        TextField descripcionField = new TextField();
        TextField precioField = new TextField();
        TextField stockField = new TextField();
        TextField marcaField = new TextField();
        TextField capacidadField = new TextField();
        TextField fechaField = new TextField();

        skuField.setPromptText("SKU");
        nombreField.setPromptText("Nombre");
        descripcionField.setPromptText("Descripción");
        precioField.setPromptText("Precio");
        stockField.setPromptText("Stock");
        marcaField.setPromptText("Marca");
        capacidadField.setPromptText("Capacidad");
        fechaField.setPromptText("Fecha Lanzamiento (YYYY-MM-DD)");

        Button crearCelularBtn = new Button("Crear Celular");
        Label resultadoLabel = new Label(); // Para mostrar el resultado

        crearCelularBtn.setOnAction(e -> {
            // Validar campos
            if (skuField.getText().isEmpty() || nombreField.getText().isEmpty() ||
                descripcionField.getText().isEmpty() || precioField.getText().isEmpty() ||
                stockField.getText().isEmpty() || marcaField.getText().isEmpty() ||
                capacidadField.getText().isEmpty() || fechaField.getText().isEmpty()) {
                resultadoLabel.setText("Por favor, complete todos los campos.");
                return;
            }

            try {
                // Crear objeto JSON con los datos del celular
                JSONObject celularJson = new JSONObject();
                celularJson.put("sku", skuField.getText());
                celularJson.put("nombre", nombreField.getText());
                celularJson.put("descripcion", descripcionField.getText());
                celularJson.put("precio", Double.parseDouble(precioField.getText()));
                celularJson.put("stock", Integer.parseInt(stockField.getText()));
                celularJson.put("marca", marcaField.getText());
                celularJson.put("capacidad", capacidadField.getText());
                celularJson.put("fechaLanzamiento", fechaField.getText());

                // Llamar al servicio para crear el celular
                String response = CelularService.crearCelular(celularJson.toString());

                // Mostrar la respuesta en la etiqueta
                resultadoLabel.setText(response);

                //  Opcional: Limpiar los campos después de la creación exitosa
                limpiarCampos(skuField, nombreField, descripcionField, precioField, stockField,
                             marcaField, capacidadField, fechaField);

            } catch (IOException ex) {
                resultadoLabel.setText("Error al comunicarse con el servidor: " + ex.getMessage());
            } catch (NumberFormatException ex) {
                resultadoLabel.setText("Error: Precio y Stock deben ser números válidos.");
            } catch (Exception ex) {
                resultadoLabel.setText("Ocurrió un error inesperado: " + ex.getMessage());
            }
        });

        VBox layout = new VBox(10, skuField, nombreField, descripcionField, precioField, stockField,
                              marcaField, capacidadField, fechaField, crearCelularBtn, resultadoLabel); // Agregamos el Label
        layout.setPadding(new Insets(20, 20, 20, 20));

        Scene scene = new Scene(layout, 400, 500); // Aumentamos el alto para el Label
        window.setScene(scene);
        window.showAndWait();
    }

    private void limpiarCampos(TextField... fields) {
        for (TextField field : fields) {
            field.clear();
        }
    }
}