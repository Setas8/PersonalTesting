<template>
  <main class="container">
    <h1>ContabilidadApp</h1>

    <!-- FORMULARIO -->
    <section class="form">
      <input v-model="concepto" placeholder="Concepto" />
      <input v-model.number="cantidad" type="number" placeholder="Cantidad" />
      <select v-model="tipo">
        <option value="ingreso">Ingreso</option>
        <option value="gasto">Gasto</option>
      </select>
      <button @click="modoEdicion ? guardarEdicion() : agregarMovimiento()">
        {{ modoEdicion ? 'Guardar cambios' : 'Añadir' }}
      </button>
    </section>

    <!-- RESUMEN -->
    <section class="resumen">
      <h2>Balance: €{{ balance }}</h2>
    </section>

    <!-- LISTADO -->
    <section class="movimientos">
      <h3>Movimientos</h3>
      <ul>
        <li v-for="(mov, index) in movimientos" :key="index">
          {{ mov.tipo === 'ingreso' ? '+' : '-' }}€{{ mov.cantidad }} - {{ mov.concepto }}
          <button @click="editarMovimiento(index)">✏️</button>
          <button @click="eliminarMovimiento(index)">🗑️</button>
        </li>
      </ul>
    </section>
  </main>
</template>

<script setup>
import { ref, computed, onMounted, watch } from 'vue';

// Estado
const concepto = ref('');
const cantidad = ref(0);
const tipo = ref('ingreso');
const movimientos = ref([]);

// Modo edición
const modoEdicion = ref(false);
const indiceEditando = ref(null);

// Cargar de localStorage al iniciar
onMounted(() => {
  const datosGuardados = localStorage.getItem('movimientos');
  if (datosGuardados) {
    movimientos.value = JSON.parse(datosGuardados);
  }
});

// Guardar en localStorage automáticamente
watch(movimientos, (nuevoValor) => {
  localStorage.setItem('movimientos', JSON.stringify(nuevoValor));
}, { deep: true });

// Añadir nuevo movimiento
const agregarMovimiento = () => {
  if (concepto.value && cantidad.value > 0) {
    movimientos.value.push({
      concepto: concepto.value,
      cantidad: cantidad.value,
      tipo: tipo.value,
    });
    limpiarFormulario();
  }
};

// Eliminar movimiento
const eliminarMovimiento = (index) => {
  if (confirm('¿Estás seguro de que quieres eliminar este movimiento?')) {
    movimientos.value.splice(index, 1);
  }
};

// Editar movimiento
const editarMovimiento = (index) => {
  const mov = movimientos.value[index];
  concepto.value = mov.concepto;
  cantidad.value = mov.cantidad;
  tipo.value = mov.tipo;
  modoEdicion.value = true;
  indiceEditando.value = index;
};

// Guardar edición
const guardarEdicion = () => {
  if (indiceEditando.value !== null) {
    movimientos.value[indiceEditando.value] = {
      concepto: concepto.value,
      cantidad: cantidad.value,
      tipo: tipo.value,
    };
    limpiarFormulario();
    modoEdicion.value = false;
    indiceEditando.value = null;
  }
};

// Resetear formulario
const limpiarFormulario = () => {
  concepto.value = '';
  cantidad.value = 0;
  tipo.value = 'ingreso';
};

// Calcular balance
const balance = computed(() => {
  return movimientos.value.reduce((acc, mov) => {
    return mov.tipo === 'ingreso'
      ? acc + mov.cantidad
      : acc - mov.cantidad;
  }, 0);
});
</script>

<style>
body {
  font-family: sans-serif;
  background: #f4f4f4;
  margin: 0;
}
.container {
  max-width: 600px;
  margin: auto;
  padding: 2rem;
  background: white;
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0,0,0,0.1);
}
input, select, button {
  margin: 0.5rem;
  padding: 0.5rem;
}
ul {
  list-style: none;
  padding: 0;
}
li {
  margin: 0.3rem 0;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
button {
  margin-left: 0.5rem;
}
</style>

