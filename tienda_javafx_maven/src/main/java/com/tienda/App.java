package com.tienda;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.BorderPane;
import javafx.stage.Stage;

public class App extends Application {

    private Stage primaryStage;

    @Override
    public void start(Stage primaryStage) {
        this.primaryStage = primaryStage;
        primaryStage.setTitle("Gestión de Tienda Tecnológica");

        // Crear el menú
        MenuBar menuBar = createMenu();

        BorderPane root = new BorderPane();
        root.setTop(menuBar);

        Scene scene = new Scene(root, 800, 600); // Tamaño inicial
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    private MenuBar createMenu() {
        MenuBar menuBar = new MenuBar();

        // Menú "Celulares"
        Menu celularesMenu = new Menu("Celulares");
        MenuItem crearCelularItem = new MenuItem("Crear Celular");
        crearCelularItem.setOnAction(e -> new CrearCelularVentana().display());

        MenuItem buscarCelularItem = new MenuItem("Buscar Celular");
        buscarCelularItem.setOnAction(e -> new BuscarCelularVentana().display());

        MenuItem eliminarCelularItem = new MenuItem("Eliminar Celular");
        eliminarCelularItem.setOnAction(e -> new EliminarCelularVentana().display(primaryStage));

        MenuItem actualizarCelularItem = new MenuItem("Actualizar Celular");
        actualizarCelularItem.setOnAction(e -> new ActualizarCelularVentana().display(primaryStage));

        MenuItem listarCelularesItem = new MenuItem("Listar Celulares");
        listarCelularesItem.setOnAction(e -> new ListarCelularesVentana().display());

        MenuItem listarCelularesFiltradoItem = new MenuItem("Listar Celulares (Filtrado)");
        listarCelularesFiltradoItem.setOnAction(e -> new ListarCelularesFiltradoVentana().display());

        celularesMenu.getItems().addAll(crearCelularItem, buscarCelularItem, eliminarCelularItem,
                                      actualizarCelularItem, listarCelularesItem, listarCelularesFiltradoItem);

        // Menú "Ayuda"
        Menu ayudaMenu = new Menu("Ayuda");
        MenuItem acercaDeItem = new MenuItem("Acerca de...");
        acercaDeItem.setOnAction(e -> mostrarAcercaDe());

        ayudaMenu.getItems().add(acercaDeItem);

        menuBar.getMenus().addAll(celularesMenu, ayudaMenu);
        return menuBar;
    }

    private void mostrarAcercaDe() {
        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("Acerca de la Aplicación");
        alert.setHeaderText("Gestión de Tienda Tecnológica");
        alert.setContentText("Desarrollado por: [Tus Nombres]\\nVersión: 1.0");
        alert.showAndWait();
    }

    public static void main(String[] args) {
        launch(args);
    }
}