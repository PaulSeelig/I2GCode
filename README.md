# GCode-Generator für CNC-Maschinen

## Ziel des Programms
Das Programm wandelt die Konturen eines PNG-Bildes in GCode für CNC-Maschinen um.

## Status
Das Programm befindet sich in einem halbfertigen Zustand.

## Installation
Die Installation ist noch in Arbeit (WIP). 

## Verwendung
1. Ziehen Sie ein PNG-Bild per Drag-and-Drop in das Programm.
2. Geben Sie die Materialwerte ein.
3. Verwenden Sie den Aproxy-Wert, um die erkannten Konturen anzupassen.
4. Drücken Sie den "GCode generieren" Button.
5. Speichern Sie den GCode als Textdatei über den Download-Button in Ihren eigenen Dokumenten.
6. Oder per Projekt Speichern im internen Speicher.
7. Gespeicherte Projekte können durch Doppelklick geöffnet werden.

## GCode-Visualisierung
Der generierte GCode kann mit https://ncviewer.com/ visualisiert werden.

## Abhängigkeiten
- OpenCV: https://github.com/opencv/opencv
- EmguCV (C# Wrapper): https://emgu.com/wiki/index.php/Main_Page

## Bekannte Probleme
- Das Bild ist möglicherweise nicht zentriert oder dauert lange zum Malen.
- Probleme bei der Verarbeitung von runden Konturen.







