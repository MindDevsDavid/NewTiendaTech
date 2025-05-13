package com.tienda;

import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

import java.io.IOException;
import java.util.Optional;

public class EliminarCelularVentana {

    public void display(Stage ownerStage) {
        Stage window = new Stage();
        window.setTitle("Eliminar Celular");
        window.initOwner(ownerStage); // Modal: Bloquea la ventana principal

        TextField skuBusquedaField = new TextField();
        skuBusquedaField.setPromptText("Ingrese el SKU del celular a eliminar");

        Button buscarBtn = new Button("Buscar");
        TextArea resultadoBusquedaArea = new TextArea();
        resultadoBusquedaArea.setEditable(false);

        Button eliminarBtn = new Button("Eliminar Celular");
        eliminarBtn.setDisable(true); // Deshabilitado al inicio

        Label mensajeLabel = new Label(); // Para mensajes de éxito/error

        buscarBtn.setOnAction(e -> {
            String sku = skuBusquedaField.getText();
            if (sku == null || sku.trim().isEmpty()) {
                resultadoBusquedaArea.setText("Por favor, ingrese el SKU del celular.");
                return;
            }

            try {
                String celularJson = CelularService.get_celular_by_sku(sku);
                if (celularJson != null && !celularJson.contains("error")) {
                    resultadoBusquedaArea.setText(celularJson); // Mostrar detalles del celular
                    eliminarBtn.setDisable(false); // Habilitar el botón de eliminar
                    mensajeLabel.setText(""); // Limpiar cualquier mensaje anterior
                } else {
                    resultadoBusquedaArea.setText("No se encontró celular con SKU: " + sku);
                    eliminarBtn.setDisable(true);
                    mensajeLabel.setText("");
                }
            } catch (IOException ex) {
                resultadoBusquedaArea.setText("Error al buscar el celular: " + ex.getMessage());
                eliminarBtn.setDisable(true);
                mensajeLabel.setText("");
            }
        });

        eliminarBtn.setOnAction(e -> {
            String sku = skuBusquedaField.getText();

            // Mostrar confirmación antes de eliminar
            Alert confirmacion = new Alert(Alert.AlertType.CONFIRMATION);
            confirmacion.setTitle("Confirmar Eliminación");
            confirmacion.setHeaderText("¿Seguro que desea eliminar el celular con SKU: " + sku + "?");
            confirmacion.setContentText("Esta acción no se puede deshacer.");

            Optional<ButtonType> resultado = confirmacion.showAndWait();
            if (resultado.isPresent() && resultado.get() == ButtonType.OK) {
                try {
                    String respuesta = CelularService.eliminarCelular(sku); // Llamar al método para eliminar
                    mensajeLabel.setText(respuesta); // Mostrar la respuesta del servidor
                    resultadoBusquedaArea.clear(); // Limpiar el área de búsqueda
                    eliminarBtn.setDisable(true); // Deshabilitar el botón nuevamente
                } catch (IOException ex) {
                    mensajeLabel.setText("Error al eliminar el celular: " + ex.getMessage());
                }
            } else {
                mensajeLabel.setText("Eliminación cancelada.");
            }
        });

        VBox layout = new VBox(10, skuBusquedaField, buscarBtn, resultadoBusquedaArea, eliminarBtn, mensajeLabel);
        layout.setPadding(new Insets(20, 20, 20, 20));

        Scene scene = new Scene(layout, 400, 400); // Aumentar el alto para el mensajeLabel
        window.setScene(scene);
        window.showAndWait();
    }
}