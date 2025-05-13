package com.tienda;

import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.IOException;

public class ListarCelularesFiltradoVentana {

    public void display() {
        Stage window = new Stage();
        window.setTitle("Listar Celulares (Filtrado)");

        // UI elements
        ComboBox<String> filtroComboBox = new ComboBox<>();
        filtroComboBox.getItems().addAll("Marca", "Rango de Precio");
        filtroComboBox.setPromptText("Seleccione el filtro");

        TextField filtroTextField = new TextField();
        filtroTextField.setPromptText("Ingrese el valor del filtro");

        TextField precioDesdeTextField = new TextField();
        precioDesdeTextField.setPromptText("Precio Desde");
        precioDesdeTextField.setVisible(false); // Initially hide
        TextField precioHastaTextField = new TextField();
        precioHastaTextField.setPromptText("Precio Hasta");
        precioHastaTextField.setVisible(false); // Initially hide

        Button buscarBtn = new Button("Buscar");
        TextArea resultadoArea = new TextArea();
        resultadoArea.setEditable(false);

        // Logic for showing/hiding price range fields
        filtroComboBox.setOnAction(e -> {
            if (filtroComboBox.getValue() != null && filtroComboBox.getValue().equals("Rango de Precio")) {
                filtroTextField.setVisible(false);
                precioDesdeTextField.setVisible(true);
                precioHastaTextField.setVisible(true);
            } else {
                filtroTextField.setVisible(true);
                precioDesdeTextField.setVisible(false);
                precioHastaTextField.setVisible(false);
            }
        });

        buscarBtn.setOnAction(e -> {
            String filtro = filtroComboBox.getValue();
            String valorFiltro = filtroTextField.getText();
            String resultado = "";

            if (filtro == null) {
                resultadoArea.setText("Por favor, seleccione un filtro.");
                return;
            }

            try {
                if (filtro.equals("Marca")) {
                    if (valorFiltro == null || valorFiltro.trim().isEmpty()) {
                        resultadoArea.setText("Por favor, ingrese la marca a buscar.");
                        return;
                    }
                    resultado = CelularService.listarCelularesPorMarca(valorFiltro);
                } else if (filtro.equals("Rango de Precio")) {
                    String precioDesdeStr = precioDesdeTextField.getText();
                    String precioHastaStr = precioHastaTextField.getText();

                    if (precioDesdeStr == null || precioDesdeStr.trim().isEmpty() ||
                        precioHastaStr == null || precioHastaStr.trim().isEmpty()) {
                        resultadoArea.setText("Por favor, ingrese el rango de precios.");
                        return;
                    }

                    try {
                        double precioDesde = Double.parseDouble(precioDesdeStr);
                        double precioHasta = Double.parseDouble(precioHastaStr);
                        resultado = CelularService.listarCelularesPorRangoPrecio(precioDesde, precioHasta);
                    } catch (NumberFormatException ex) {
                        resultadoArea.setText("Por favor, ingrese precios válidos.");
                        return;
                    }

                }

                resultadoArea.setText(formatarCelulares(resultado));

            } catch (IOException ex) {
                resultadoArea.setText("Error al comunicarse con el servidor: " + ex.getMessage());
            } catch (Exception ex) {
                resultadoArea.setText("Ocurrió un error inesperado: " + ex.getMessage());
            }

        });

        VBox layout = new VBox(10, filtroComboBox, filtroTextField, precioDesdeTextField, precioHastaTextField, buscarBtn, resultadoArea);
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