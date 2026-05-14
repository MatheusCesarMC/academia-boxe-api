const apiUrl = "http://localhost:5126/api";

let alunoEditandoId = null;

async function mostrarAlunos() {

    const resposta = await fetch(`${apiUrl}/Alunos`);
    const alunos = await resposta.json();

    const conteudo = document.getElementById("conteudo");

    conteudo.innerHTML = `
        <h2>Alunos</h2>

        <input 
            type="text"
            id="pesquisaAluno"
            placeholder="Pesquisar aluno..."
        >

        <form id="formAluno">
            <input type="text" id="nomeAluno" placeholder="Nome" required>

            <input type="email" id="emailAluno" placeholder="Email" required>

            <input type="text" id="telefoneAluno" placeholder="Telefone" required>

            <input type="text" id="professorAluno" placeholder="Professor Responsável" required>

            <button type="submit">Cadastrar Aluno</button>
        </form>

        <div id="listaAlunos"></div>
    `;

    function renderizarAlunos(listaAlunos) {

        const lista = document.getElementById("listaAlunos");

        lista.innerHTML = "";

        listaAlunos.forEach(aluno => {

            lista.innerHTML += `
                <div class="card">

                    <h3>${aluno.nome}</h3>

                    <p>
                        <strong>Email:</strong>
                        ${aluno.email}
                    </p>

                    <p>
                        <strong>Telefone:</strong>
                        ${aluno.telefone}
                    </p>

                    <p>
                        <strong>Professor:</strong>
                        ${aluno.professorResponsavel}
                    </p>

                    <button onclick="editarAluno(
                        '${aluno.id}',
                        '${aluno.nome}',
                        '${aluno.email}',
                        '${aluno.telefone}',
                        '${aluno.professorResponsavel}'
                    )">
                        Editar
                    </button>

                    <button onclick="deletarAluno('${aluno.id}')">Excluir</button>

                </div>
            `;
        });
    }

    renderizarAlunos(alunos);

    document
        .getElementById("pesquisaAluno")
        .addEventListener("input", function () {

            const texto = this.value.toLowerCase();

            const filtrados = alunos.filter(aluno =>

                aluno.nome.toLowerCase().includes(texto) ||

                aluno.professorResponsavel
                    .toLowerCase()
                    .includes(texto)
            );

            renderizarAlunos(filtrados);
        });

    document
        .getElementById("formAluno")
        .addEventListener("submit", cadastrarAluno);
}

async function cadastrarAluno(event) {

    event.preventDefault();

    const aluno = {
        nome: document.getElementById("nomeAluno").value,
        email: document.getElementById("emailAluno").value,
        telefone: document.getElementById("telefoneAluno").value,
        professorResponsavel: document.getElementById("professorAluno").value
    };

    if (alunoEditandoId) {

    await fetch(`${apiUrl}/Alunos/${alunoEditandoId}`, {

        method: "PUT",

        headers: {
            "Content-Type": "application/json"
        },

        body: JSON.stringify(aluno)
    });

    alunoEditandoId = null;

    } else {

        await fetch(`${apiUrl}/Alunos`, {

            method: "POST",

            headers: {
                "Content-Type": "application/json"
            },

            body: JSON.stringify(aluno)
        });
    }

    mostrarAlunos();
}

async function mostrarProfessores() {

    const resposta = await fetch(`${apiUrl}/Professores`);
    const professores = await resposta.json();

    const conteudo = document.getElementById("conteudo");

    conteudo.innerHTML = `
        <h2>Professores</h2>

        <input
            type="text"
            id="pesquisaProfessor"
            placeholder="Pesquisar professor..."
        >

        <form id="formProfessor">

            <input
                type="text"
                id="nomeProfessor"
                placeholder="Nome"
                required
            >

            <input
                type="text"
                id="especialidadeProfessor"
                placeholder="Especialidade"
                required
            >

            <input
                type="email"
                id="emailProfessor"
                placeholder="Email"
                required
            >

            <input
                type="text"
                id="telefoneProfessor"
                placeholder="Telefone"
                required
            >

            <button type="submit">
                Cadastrar Professor
            </button>

        </form>

        <div id="listaProfessores"></div>
    `;

    function renderizarProfessores(listaProfessores) {

        const lista = document.getElementById("listaProfessores");

        lista.innerHTML = "";

        listaProfessores.forEach(professor => {

            lista.innerHTML += `
                <div class="card">

                    <h3>${professor.nome}</h3>

                    <p>
                        <strong>Especialidade:</strong>
                        ${professor.especialidade}
                    </p>

                    <p>
                        <strong>Email:</strong>
                        ${professor.email}
                    </p>

                    <p>
                        <strong>Telefone:</strong>
                        ${professor.telefone}
                    </p>

                    <button onclick="deletarProfessor('${professor.id}')">
                        Excluir
                    </button>

                </div>
            `;
        });
    }

    renderizarProfessores(professores);

    document
        .getElementById("pesquisaProfessor")
        .addEventListener("input", function () {

            const texto = this.value.toLowerCase();

            const filtrados = professores.filter(professor =>

                professor.nome.toLowerCase().includes(texto) ||

                professor.especialidade
                    .toLowerCase()
                    .includes(texto)
            );

            renderizarProfessores(filtrados);
        });

    document
        .getElementById("formProfessor")
        .addEventListener("submit", cadastrarProfessor);
}

async function cadastrarProfessor(event) {

    event.preventDefault();

    const professor = {
        nome: document.getElementById("nomeProfessor").value,
        especialidade: document.getElementById("especialidadeProfessor").value,
        email: document.getElementById("emailProfessor").value,
        telefone: document.getElementById("telefoneProfessor").value
    };

    await fetch(`${apiUrl}/Professores`, {
        method: "POST",

        headers: {
            "Content-Type": "application/json"
        },

        body: JSON.stringify(professor)
    });

    mostrarProfessores();
}

async function deletarAluno(id) {

    const confirmar = confirm("Deseja excluir este aluno?");

    if (!confirmar) {
        return;
    }

    await fetch(`${apiUrl}/Alunos/${id}`, {
        method: "DELETE"
    });

    mostrarAlunos();
}

async function deletarProfessor(id) {

    const confirmar = confirm("Deseja excluir est professor?");

    if (!confirmar) {
        return;
    }

    await fetch(`${apiUrl}/Professores/${id}`, {
        method: "DELETE"
    });

    mostrarProfessores();
}

function editarAluno(id, nome, email, telefone, professor) {

    alunoEditandoId = id;

    document.getElementById("nomeAluno").value = nome;

    document.getElementById("emailAluno").value = email;

    document.getElementById("telefoneAluno").value = telefone;

    document.getElementById("professorAluno").value = professor;
}