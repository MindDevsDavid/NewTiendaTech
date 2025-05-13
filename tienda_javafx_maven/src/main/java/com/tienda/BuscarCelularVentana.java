package com.tienda;

import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

import java.io.IOException;

public class BuscarCelularVentana {

    public void display() {
        Stage window = new Stage();
        window.setTitle("Buscar Celular por SKU");

        TextField skuBusquedaField = new TextField();
        skuBusquedaField.setPromptText("Ingrese el SKU del celular");

        Button buscarBtn = new Button("Buscar");
        TextArea resultadoArea = new TextArea();
        resultadoArea.setEditable(false);

        buscarBtn.setOnAction(e -> {
            String sku = skuBusquedaField.getText();
            if (sku == null || sku.trim().isEmpty()) {
                resultadoArea.setText("Por favor, ingrese el SKU del celular.");
                return;
            }

            try {
                String resultadoBusqueda = "";

                //  Buscar por SKU
                try {
                    String celularJson = CelularService.get_celular_by_sku(sku);
                    if (celularJson != null && !celularJson.contains("error")) {
                        resultadoBusqueda = celularJson;
                    } else {
                        resultadoBusqueda = "No se encontró celular con SKU: " + sku;
                    }
                } catch (IOException ex) {
                    resultadoArea.setText("Error al buscar por SKU: " + ex.getMessage());
                    return; // Salir en caso de error
                }


                resultadoArea.setText(resultadoBusqueda);

            } catch (Exception ex) {
                resultadoArea.setText("Ocurrió un error inesperado: " + ex.getMessage());
            }
        });

        VBox layout = new VBox(10, skuBusquedaField, buscarBtn, resultadoArea);
        layout.setPadding(new Insets(20, 20, 20, 20));

        Scene scene = new Scene(layout, 400, 300);
        window.setScene(scene);
        window.showAndWait();
    }
}