function Coletar(){
    let a = document.querySelector('.input-arma').value
    console.log(a)
    ApiData(a)
}

async function ApiData(a){
    let c = await fetch(`https://localhost:7110/api/Armas/${a}`).then(response => response.json())
    let b = await fetch(`https://localhost:7110/api/Jogoes/${c.jogoid}`).then(response => response.json())
    console.log(b, c)
    TrocarDados(b, c)
}

function TrocarDados(b, c){
    document.querySelector('.nomearma').innerHTML = `Nome: ${c.nome}`
    document.querySelector('.jogoarma').innerHTML = `Primeiro aparecimento: ${b.nome}`
    document.querySelector('.descarma').innerHTML = `Descrição: ${c.descricao}`
}

function toggleSidebar() {
    const sidebar = document.getElementById('sidebar');
    const toggleButton = document.querySelector('.sidebar-toggle');

    if (sidebar.classList.contains('minimized')) {
        sidebar.classList.remove('minimized');
        toggleButton.innerHTML = '&#9665;'; // Setinha para expandir
    } else {
        sidebar.classList.add('minimized');
        toggleButton.innerHTML = '&#9654;'; // Setinha para minimizar
    }
}

