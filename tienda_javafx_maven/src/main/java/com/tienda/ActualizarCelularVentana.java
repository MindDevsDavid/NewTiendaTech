package com.tienda;

import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import org.json.JSONObject;

import java.io.IOException;

public class ActualizarCelularVentana {

    public void display(Stage ownerStage) {
        Stage window = new Stage();
        window.setTitle("Actualizar Celular");
        window.initOwner(ownerStage); // Modal: Bloquea la ventana principal

        TextField skuBusquedaField = new TextField();
        skuBusquedaField.setPromptText("Ingrese el SKU del celular a actualizar");

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

        // Deshabilitar campos al inicio, se habilitan después de la búsqueda
        skuField.setDisable(true);
        nombreField.setDisable(true);
        descripcionField.setDisable(true);
        precioField.setDisable(true);
        stockField.setDisable(true);
        marcaField.setDisable(true);
        capacidadField.setDisable(true);
        fechaField.setDisable(true);

        Button buscarBtn = new Button("Buscar Celular");
        Button actualizarBtn = new Button("Actualizar Celular");
        actualizarBtn.setDisable(true); // Deshabilitar hasta que se encuentre el celular

        Label resultadoLabel = new Label(); // Para mostrar resultados

        buscarBtn.setOnAction(e -> {
            String skuABuscar = skuBusquedaField.getText();
            if (skuABuscar == null || skuABuscar.trim().isEmpty()) {
                resultadoLabel.setText("Por favor, ingrese el SKU del celular a buscar.");
                return;
            }

            try {
                String celularJson = CelularService.get_celular_by_sku(skuABuscar); // Usar el método de CelularService
                if (celularJson != null && !celularJson.contains("error")) { // Verificar si se encontró el celular
                    JSONObject jsonObject = new JSONObject(celularJson);

                    // Llenar los campos con los datos del celular encontrado
                    skuField.setText(jsonObject.getString("sku"));
                    nombreField.setText(jsonObject.getString("nombre"));
                    descripcionField.setText(jsonObject.getString("descripcion"));
                    precioField.setText(String.valueOf(jsonObject.getDouble("precio")));
                    stockField.setText(String.valueOf(jsonObject.getInt("stock")));
                    marcaField.setText(jsonObject.getString("marca"));
                    capacidadField.setText(String.valueOf(jsonObject.getInt("capacidad")));
                    fechaField.setText(jsonObject.getString("fechaLanzamiento"));

                    // Habilitar los campos para la edición
                    skuField.setDisable(false);
                    nombreField.setDisable(false);
                    descripcionField.setDisable(false);
                    precioField.setDisable(false);
                    stockField.setDisable(false);
                    marcaField.setDisable(false);
                    capacidadField.setDisable(false);
                    fechaField.setDisable(false);
                    actualizarBtn.setDisable(false); // Habilitar el botón de actualizar
                    resultadoLabel.setText("Celular encontrado. Listo para actualizar.");

                } else {
                    resultadoLabel.setText("No se encontró celular con SKU: " + skuABuscar);
                    // Limpiar campos
                    skuField.clear();
                    nombreField.clear();
                    descripcionField.clear();
                    precioField.clear();
                    stockField.clear();
                    marcaField.clear();
                    capacidadField.clear();
                    fechaField.clear();

                    //Deshabilitar
                    skuField.setDisable(true);
                    nombreField.setDisable(true);
                    descripcionField.setDisable(true);
                    precioField.setDisable(true);
                    stockField.setDisable(true);
                    marcaField.setDisable(true);
                    capacidadField.setDisable(true);
                    fechaField.setDisable(true);
                    actualizarBtn.setDisable(true);
                }
            } catch (IOException ex) {
                resultadoLabel.setText("Error al buscar el celular: " + ex.getMessage());
            }
        });

        actualizarBtn.setOnAction(e -> {
            try {
                // Validar campos
                if (skuField.getText().isEmpty() || nombreField.getText().isEmpty() ||
                        descripcionField.getText().isEmpty() || precioField.getText().isEmpty() ||
                        stockField.getText().isEmpty() || marcaField.getText().isEmpty() ||
                        capacidadField.getText().isEmpty() || fechaField.getText().isEmpty()) {
                    resultadoLabel.setText("Por favor, complete todos los campos.");
                    return;
                }
                // Crear objeto JSON con los datos actualizados
                JSONObject celularJson = new JSONObject();
                celularJson.put("sku", skuField.getText()); // Incluir el SKU para la actualización
                celularJson.put("nombre", nombreField.getText());
                celularJson.put("descripcion", descripcionField.getText());
                celularJson.put("precio", Double.parseDouble(precioField.getText()));
                celularJson.put("stock", Integer.parseInt(stockField.getText()));
                celularJson.put("marca", marcaField.getText());
                celularJson.put("capacidad", Integer.parseInt(capacidadField.getText())); //capacidad es int
                celularJson.put("fechaLanzamiento", fechaField.getText());

                // Llamar al servicio para actualizar el celular
                String response = CelularService.actualizarCelular(skuField.getText(), celularJson.toString()); // Pasar el SKU y el JSON
                resultadoLabel.setText(response); // Mostrar el resultado de la actualización

                // Limpiar los campos después de la actualización
                skuField.clear();
                nombreField.clear();
                descripcionField.clear();
                precioField.clear();
                stockField.clear();
                marcaField.clear();
                capacidadField.clear();
                fechaField.clear();

                // Deshabilitar los campos después de la actualización
                skuField.setDisable(true);
                nombreField.setDisable(true);
                descripcionField.setDisable(true);
                precioField.setDisable(true);
                stockField.setDisable(true);
                marcaField.setDisable(true);
                capacidadField.setDisable(true);
                fechaField.setDisable(true);
                actualizarBtn.setDisable(true);

            } catch (IOException ex) {
                resultadoLabel.setText("Error al actualizar el celular: " + ex.getMessage());
            } catch (NumberFormatException ex) {
                resultadoLabel.setText("Error: Precio y Stock deben ser números válidos.");
            } catch (Exception ex) {
                resultadoLabel.setText("Ocurrió un error inesperado: " + ex.getMessage());
            }
        });

        VBox layout = new VBox(10, skuBusquedaField, buscarBtn, skuField, nombreField, descripcionField, precioField, stockField,
                marcaField, capacidadField, fechaField, actualizarBtn, resultadoLabel);
        layout.setPadding(new Insets(20, 20, 20, 20));

        Scene scene = new Scene(layout, 400, 550); // Ajustar el tamaño de la ventana
        window.setScene(scene);
        window.showAndWait();
    }
}