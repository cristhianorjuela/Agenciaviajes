
document.addEventListener("DOMContentLoaded", function () {
    // Obtener elementos del DOM
    const exploreButton = document.querySelector(".btn");
    const featureCards = document.querySelectorAll(".feature");

    // Agregar evento clic al botón "Explorar Hoteles"
    exploreButton.addEventListener("click", function (event) {
        event.preventDefault();
        // Aquí puedes redirigir a la página de búsqueda de hoteles
        window.location.href = "/hoteles/buscar";
    });

    // Agregar eventos de mouse a las tarjetas de características
    featureCards.forEach(function (card) {
        card.addEventListener("mouseover", function () {
            card.style.backgroundColor = "#f5f5f5";
        });

        card.addEventListener("mouseout", function () {
            card.style.backgroundColor = "#fff";
        });
    });
});
