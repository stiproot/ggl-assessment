<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated class="">
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          @click="minimized = !minimized"
          aria-label="Menu"
          icon="menu"
        />
        <q-toolbar-title> slst-sample-ui </q-toolbar-title>
        <div>v0.0.1-beta</div>
      </q-toolbar>
    </q-header>

    <q-drawer v-model="minimized" show-if-above bordered class="bg-grey-2">
      <q-list>
        <q-item-label header>menu</q-item-label>

        <q-item clickable tag="a" to="/auth" exact>
          <q-item-section avatar>
            <q-icon name="code" />
          </q-item-section>
          <q-item-section>
            <q-item-label>Auth</q-item-label>
          </q-item-section>
        </q-item>

        <q-item clickable tag="a" to="img" exact>
          <q-item-section avatar>
            <q-icon name="code" />
          </q-item-section>
          <q-item-section>
            <q-item-label>Img</q-item-label>
          </q-item-section>
        </q-item>

        <q-item
          clickable
          tag="a"
          target="_blank"
          href="https://github.com/stiproot/ggl-assessment"
        >
          <q-item-section avatar>
            <q-icon name="code" />
          </q-item-section>
          <q-item-section>
            <q-item-label>GitHub</q-item-label>
            <q-item-label caption>github.com/ggl-assessment</q-item-label>
          </q-item-section>
        </q-item>

      </q-list>
    </q-drawer>

    <q-page-container>
      <router-view></router-view>
      <LoadingComponent />
    </q-page-container>
  </q-layout>
</template>

<script>
import { reactive, toRefs } from "vue";
import LoadingComponent from "@/components/LoadingComponent.vue";
import { useLayoutStore, LayoutProvider } from "@/stores/layout.store";

export default {
  name: "LayoutDefault",
  components: {
    LoadingComponent,
  },
  setup() {
    const layoutProvider = new LayoutProvider(useLayoutStore());

    const { minimized } = layoutProvider;

    const data = reactive({
      minimized,
    });

    return {
      ...toRefs(data),
    };
  },
};
</script>
